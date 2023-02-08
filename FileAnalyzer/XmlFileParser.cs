using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public List<string> ParseFile(string attribute)
        {
            throw new NotImplementedException();
        }
    }
}
