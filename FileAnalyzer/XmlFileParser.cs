using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileAnalyzer
{
    public class XmlFileParser : IFileParser
    {
        private readonly string _content;

        public XmlFileParser(string path)
        {
            _content = GetFile(path);
        }

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

        public List<string> ParseFile(string attribute)
        {
            throw new NotImplementedException();
        }
    }
}
