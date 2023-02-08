using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public class Phrase
    {
        public List<string> Interpret(string input)
        {
            string[] args = input.Split(' ');
            string attribute = args[0];
            string method = args[1];
            string value = args[2];
            string path = args[3];
            string fileType = path.Split('.').Last();
            IFileParser file = GetParser(fileType, path);
            FileService service = new FileService(file);

            return Call(attribute, method, value, service);

        }

        private List<string> Call(string attribute, string method, string value, FileService service)
        {
            switch (method)
            {
                case "-gt":
                    return service.ValueGreaterThan(attribute, value);

                case "-st":
                    return service.ValueSmallerThan(attribute, value);

                case "=":
                    return service.ValueEquals(attribute, value);

                default:
                    throw new InvalidOperationException();
            }
        }

        private IFileParser GetParser(string fileType, string path)
        {
            switch (fileType)
            {
                case "json":
                    return new JsonFileParser(path);

                case "xml":
                    return new XmlFileParser(path);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
