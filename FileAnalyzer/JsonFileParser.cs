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
    /// <summary>
    /// Provides methods for parsing json file.
    /// </summary>
    public class JsonFileParser : IFileParser
    {
        private readonly string _content;

        public JsonFileParser(string path)
        {
            _content = GetFile(path);
        }

        /// <summary>
        /// Gets json file from directory based on a given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String representation of json file.</returns>
        /// <exception cref="FileNotFoundException"></exception>
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

        /// <summary>
        /// Iterates trough json attributes, finds searched attribute
        /// and parses its values into a list of strings.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>List of strings containing searched value attributes.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<string> ParseFile(string attribute)
        {
            JObject json = JObject.Parse(_content);
            string path = "$" + attribute;

            var obj = json.Count;




            var tokens = json.SelectTokens("$..........employees");
            
            
            if (tokens.Count() == 0)
            {
                path = "$." + attribute;
            }
            tokens = json.SelectTokens(path);





            return json.SelectTokens(path).Select(t => t.ToString()).ToList();
        }

    }
}
