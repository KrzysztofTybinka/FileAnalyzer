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
            string method = args[0];
            string value = args[1];
            string path = args[2];
            string fileType = path.Split('.').Last();
            IFileParser file;

            switch (fileType)
            {
                case "json":
                    file = new JsonFileParser(path);
                    break;

                case "xml":
                    file = new XmlFileParser(path);
                    break;

                default:
                    break;
            }

            switch (method)
            {
                case "value-gt":
                    break;

                case "value-st":
                    break;

                case "value=":
                    break;

                default:
                    break;
            }
        }
    }
}
