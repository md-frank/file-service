using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ImageMagick;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service.ServiceImpls
{
    public abstract class QueuingImageConverter : IImageConverter
    {
        /// <summary>
        /// 转换中的任务
        /// </summary>
        private readonly Dictionary<string, TaskContext> _convertingTasks = new Dictionary<string, TaskContext>();

        public Task ConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod)
        {
            return Task.Run(() =>
            {
                TaskContext taskInfo = null;
                lock (_convertingTasks)
                {
                    //用dstFilePath作为任务唯一ID，多次转换请求自动合并
                    if (!_convertingTasks.TryGetValue(dstFilePath, out taskInfo))
                    {
                        taskInfo = new TaskContext(this, dstFilePath);
                        _convertingTasks[dstFilePath] = taskInfo;

                        OnConvertAsync(srcFilePath, srcMime, dstFilePath, dstImgMod, taskInfo);
                    }
                }

                //等待任务转换完成
                taskInfo.WaitComplete();
            });
        }

        protected abstract Task OnConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod, TaskContext taskCtx);

        protected class TaskContext : IDisposable
        {
            private readonly QueuingImageConverter _converter;
            private readonly ManualResetEvent _completeEvent;
            private Exception _error;
            private readonly string _taskId;

            public TaskContext(QueuingImageConverter converter, string taskId)
            {
                _converter = converter;
                _taskId = taskId;
                _completeEvent = new ManualResetEvent(false);
            }

            public void Dispose()
            {
                _completeEvent?.Dispose();
            }

            public void Complete(Exception ex = null)
            {
                lock (_converter._convertingTasks)
                {
                    _converter._convertingTasks.Remove(_taskId);
                }

                _error = ex;
                _completeEvent.Set();
                _completeEvent.Dispose();
            }

            public void WaitComplete()
            {
                _completeEvent.WaitOne();
                if (_error != null)
                    throw _error;
            }
        }
    }
}
