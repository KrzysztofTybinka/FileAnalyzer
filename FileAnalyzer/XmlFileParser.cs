using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for parsing json file.
    /// </summary>
    public class XmlFileParser : IFileParser
    {
        private readonly string _content;

        public XmlFileParser(string content)
        {
            _content = content;
        }


        /// <summary>
        /// Iterates trough xml attributes, finds searched attribute
        /// and parses its values into a list of strings.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>List of strings containing searched value attributes.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<string?> ParseFile(string attribute)
        {
            XDocument xmlDoc = XDocument.Parse(_content);

            List<string?> list = xmlDoc.Descendants(attribute)
                .Select(x => x.Value ?? null)
                .ToList();

            if (list.Count == 0)
            {
                throw new KeyNotFoundException();
            }
            return list;
        }
    }
}
