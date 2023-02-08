using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public List<string> ParseFile(string attribute)
        {
            throw new NotImplementedException();
        }
    }
}
