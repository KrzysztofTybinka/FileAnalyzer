using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for parsing json file.
    /// </summary>
    public class XmlFIleParser : IFileParser
    {
        private readonly string _content;

        public XmlFIleParser(string content)
        {
            _content = content;
        }


        /// <summary>
        /// Iterates trough json attributes, finds searched attribute
        /// and parses its values into a list of strings.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>List of strings containing searched value attributes.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<string?> ParseFile(string attribute)
        {
            JObject json = JObject.Parse(_content);

            List<string?> list = json.Properties()
                .Descendants()
                .OfType<JProperty>()
                .Where(x => x.Name == attribute)
                .Values<string?>()
                .ToList();

            if (list.Count == 0)
            {
                throw new KeyNotFoundException();
            }
            return list;
        }

    }
}
