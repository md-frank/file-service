using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mondol.FileService
{
    internal static class ApiChannelExtensions
    {
        public static async Task<JObject> GetJObjectAsync(this IApiChannel apiChannel, HttpMethod method, string apiPath, HttpContent reqContent = null)
        {
            using (var tr = await apiChannel.GetTextReaderAsync(method, apiPath, reqContent))
            {
                return await JObject.LoadAsync(new JsonTextReader(tr));
            }
        }

        ///// <summary>
        ///// 取返回结果的
        ///// </summary>
        //public static async Task<TEntity> GetEntityAsync<TEntity>(this IApiChannel apiChannel, HttpMethod method, string apiPath, HttpContent reqContent = null)
        //{
        //    var js = apiChannel.Service.GetRequiredService<IJsonSerializer>();
        //    var rspStream = await apiChannel.GetStreamAsync(method, apiPath, reqContent);
        //    using (var rspReader = new StreamReader(rspStream))
        //    {
        //        return (TEntity)js.Deserialize(rspReader, typeof(TEntity));
        //    }
        //}

        ///// <summary>
        ///// 取对象的
        ///// </summary>
        //public static async Task<TResult> GetResultModelAsync<TResult>(this IApiChannel apiChannel, HttpMethod method, string apiPath, HttpContent reqContent, string resultPath)
        //{
        //    var resultPaths = resultPath?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (resultPaths?.Length < 1)
        //        throw new ArgumentException(nameof(resultPath));

        //    var rootJson = await GetResultJObjectAsync(apiChannel, method, apiPath, reqContent);

        //    JToken datJson = rootJson;
        //    foreach (var rPath in resultPaths)
        //    {
        //        datJson = datJson[rPath];
        //        if (datJson == null || !datJson.HasValues)
        //            break;
        //    }

        //    TResult data = default(TResult);
        //    if (datJson != null && datJson.HasValues)
        //    {
        //        var js = ServiceProviderFactory.Service.Resolve<IJsonSerializer>();
        //        data = (TResult)js.Deserialize(datJson, typeof(TResult));
        //    }
        //    return data;
        //}

        ///// <summary>
        ///// 取对象的
        ///// </summary>
        //public static async Task<DataResult<TResult>> GetDataResultObjectAsync<TResult>(this IApiChannel apiChannel, HttpMethod method, string apiPath, HttpContent reqContent = null, string resultPath = null)
        //{
        //    var resultPaths = resultPath?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        //    var rootJson = await GetResultJObjectAsync(apiChannel, method, apiPath, reqContent);

        //    JToken datJson = rootJson;
        //    foreach (var rPath in resultPaths)
        //    {
        //        datJson = datJson[rPath];
        //        if (datJson == null || !datJson.HasValues)
        //            break;
        //    }

        //    TResult data = default(TResult);
        //    if (datJson != null && datJson.HasValues)
        //    {
        //        var js = ServiceProviderFactory.Service.Resolve<IJsonSerializer>();
        //        data = (TResult)js.Deserialize(datJson, typeof(TResult));
        //    }
        //    var errCode = rootJson.Value<int>("errno");
        //    var errMsg = rootJson.Value<string>("error");
        //    return new DataResult<TResult>(errCode, errMsg)
        //    {
        //        Data = data
        //    };
        //}

        ///// <summary>
        ///// 取列表的
        ///// </summary>
        //public static async Task<DataResult<TResult[]>> GetDataResultArrayAsync<TResult>(this IApiChannel apiChannel, HttpMethod method, string apiPath, HttpContent reqContent = null, string resultPath = null) where TResult : class
        //{
        //    var resultPaths = resultPath?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        //    var rootJson = await GetResultJObjectAsync(apiChannel, method, apiPath, reqContent);

        //    JToken datJson = rootJson;
        //    foreach (var rPath in resultPaths)
        //    {
        //        datJson = datJson[rPath];
        //        if (datJson == null || !datJson.HasValues)
        //            break;
        //    }

        //    TResult[] data = default(TResult[]);
        //    if (datJson != null && datJson.HasValues)
        //    {
        //        var js = ServiceProviderFactory.Service.Resolve<IJsonSerializer>();
        //        data = (TResult[])js.Deserialize(datJson, typeof(TResult[]));
        //    }
        //    var errCode = rootJson.Value<int>("errno");
        //    var errMsg = rootJson.Value<string>("error");
        //    return new DataResult<TResult[]>(errCode, errMsg)
        //    {
        //        Data = data
        //    };
        //}
    }
}
