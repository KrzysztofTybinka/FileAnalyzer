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

        public XmlFileParser(string path)
        {
            _content = GetFile(path);
        }

        /// <summary>
        /// Gets xml file from directory based on a given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String representation of xml file.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public string GetFile(string path)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                string xmlString = xmlDoc.OuterXml;

                return xmlString;
            }
            catch (Exception)
            {
                throw new FileNotFoundException(path);
            }
        }

        /// <summary>
        /// Iterates trough xml attributes, finds searched attribute
        /// and parses its values into a list of strings.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>List of strings containing searched value attributes.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<string> ParseFile(string attribute)
        {
            XDocument xmlDoc = XDocument.Parse(_content);
            List<string> list = new List<string>();
            IEnumerable<XElement> xElements = xmlDoc.Descendants(attribute);

            foreach (var item in xElements)
            {
                list.Add(item.Value);
            }

            return list;
        }
    }
}
