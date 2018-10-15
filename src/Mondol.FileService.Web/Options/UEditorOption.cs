using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Mondol.WebPlatform;
using Newtonsoft.Json.Linq;

namespace Mondol.FileService.Web.Options
{
    public class UEditorOption
    {
        public JObject Items { get; }

        public UEditorOption(IHostingEnvironment hostEnv)
        {
            var cfgPath = Path.Combine(hostEnv.GetConfigPath(), "ueditor.json");
            if (!File.Exists(cfgPath))
                throw new FileNotFoundException($"配置文件 {cfgPath} 不存在");

            try
            {
                var json = File.ReadAllText(cfgPath, Encoding.UTF8);
                Items = JObject.Parse(json);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"配置文件 {cfgPath} 格式错误：{ex.Message}");
            }
        }



        public T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public string[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<string>()).ToArray();
        }

        public string GetString(string key)
        {
            return GetValue<string>(key);
        }

        public int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}
