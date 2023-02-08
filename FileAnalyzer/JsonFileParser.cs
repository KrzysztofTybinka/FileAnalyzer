using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public class JsonFileParser : IFileParser
    {
        private readonly string _content;

        public JsonFileParser(string path)
        {
            _content = GetFile(path);
        }

        public string GetFile(string path)
        {
            try
            {
                string jsonString;
                using (StreamReader reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                }

                return jsonString;
            }
            catch (Exception)
            {
                throw new FileNotFoundException(path);
            }
        }

        public List<string> ParseFile(string path)
        {
            JObject json = JObject.Parse(_content);
            var attributes = path.Split('.');
            string builder = "";

            var x = json.SelectTokens("$[]");

            for (int i = 0; i < attributes.Length; i++)
            {
                JToken? token = (json.SelectToken(attributes[i]));

                if (token is null)
                {
                    throw new NullReferenceException();
                }
                if (token is JArray)
                {
                    builder += attributes[i] + "[*]";
                }
                if (token is JObject)
                {
                    builder += attributes[i];
                }
            }

            return json.SelectTokens(builder).Select(t => t.ToString()).ToList();

        }

    }
}
