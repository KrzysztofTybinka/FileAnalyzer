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
        public void Interpret(string input)
        {
            string[] args = input.Split(' ');
            string attribute = args[0];
            string method = args[1];
            string value = args[2];
            string path = args[3];
            string fileType = path.Split('.').Last();
            IFileParser file = FileType(fileType, path);

            FileService service = new FileService(file);

            if (method == "-gt")
            {
                service.ValueGreaterThan(attribute, value);
            }
            else if (method == "-st")
            {
                service.ValueSmallerThan(attribute, value);
            }
            else if (method == "=")
            {
                service.ValueEquals(attribute, value);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private IFileParser FileType(string fileType, string path)
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
