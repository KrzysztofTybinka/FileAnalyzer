using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public interface IFileParser
    {
        public string GetFile(string path);
        public List<string> ParseFile(string attribute);
    }
}
