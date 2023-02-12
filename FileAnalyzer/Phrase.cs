using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for input data interpretation.
    /// </summary>
    public class Phrase
    {
        /// <summary>
        /// Interprets input value and returns list of 
        /// values that are a result of input interpretation.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<string?> Interpret(string input)
        {
            try
            {
                string[] args = input.Split(' ');
                string key = args[0];
                string method = args[1];
                string value = args[2];
                string path = args[3];
                string fileType = path.Split('.').Last();
                string content = FileDownloader.GetContent(path);

                IFileParser file = GetParser(fileType, content);
                FileService service = new FileService(file);

                return Call(key, method, value, service);
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Calls proper method based on given function name.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="method"></param>
        /// <param name="value"></param>
        /// <param name="service"></param>
        /// <returns>List containing string representation of objects obtained by input function.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private List<string?> Call(string key, string method, string value, FileService service)
        {
            switch (method)
            {
                case "-gt":
                    return service.ValueGreaterThan(key, value);

                case "-st":
                    return service.ValueSmallerThan(key, value);

                case "-pt":
                    return service.PrintValues(key, value);

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Creates proper FileParser object.
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="path"></param>
        /// <returns>IFileParser.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IFileParser GetParser(string fileType, string content)
        {
            switch (fileType)
            {
                case "json":
                    return new XmlFIleParser(content);

                case "xml":
                    return new XmlFileParser(content);

                default:
                    throw new FileLoadException();
            }
        }
    }
}
