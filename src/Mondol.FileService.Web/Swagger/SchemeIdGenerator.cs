using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 生成SchemeId
    /// </summary>
    public class SchemeIdGenerator
    {
        private readonly Regex _rexTypeName = new Regex(@"(?:[a-zA-Z0-9_]+\.|`\d|\])", RegexOptions.Singleline);
        private readonly Dictionary<string, int> _nameCounter = new Dictionary<string, int>();
        private readonly Dictionary<Type, string> _typeNameDict = new Dictionary<Type, string>();

        public string SchemaIdSelector(Type type)
        {
            if (!_typeNameDict.TryGetValue(type, out var name))
            {
                name = GetTypeName(type);
                var nCount = GetNameCount(name, out var nameExists);
                if (nameExists)
                    name += nCount;

                _typeNameDict[type] = name;
            }
            return name;
        }

        private int GetNameCount(string name, out bool isExists)
        {
            isExists = true;
            if (!_nameCounter.TryGetValue(name, out var count))
            {
                isExists = false;
                _nameCounter[name] = 1;
                return 1;
            }

            _nameCounter[name] = ++count;
            return count;
        }

        private string GetTypeName(Type type)
        {
            return _rexTypeName.Replace(type.ToString(), "").Replace("[", "_");
        }
    }
}
