using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public interface IFileParser
    {
        List<string> ParseFile(string filePath, string attribute);
    }
}
