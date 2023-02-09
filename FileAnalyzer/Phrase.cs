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
        public List<string> Interpret(string input)
        {
            try
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
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Calls proper method based on given function name.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="method"></param>
        /// <param name="value"></param>
        /// <param name="service"></param>
        /// <returns>List containing string representation of objects obtained by input function.</returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Creates proper FileParser object.
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="path"></param>
        /// <returns>IFileParser.</returns>
        /// <exception cref="InvalidOperationException"></exception>
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
