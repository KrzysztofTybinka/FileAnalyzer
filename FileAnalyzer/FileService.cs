using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public class FileService
    {
        private IFileParser _fileParser;

        public FileService(IFileParser fileParser)
        {
            _fileParser = fileParser;
        }

        public List<string> ValueGreaterThan(string attribute, string value)
        {
            List<int> list = _fileParser.ParseFile(attribute).Cast<int>().ToList();
            int parameter = int.Parse(value);

            return list.Where(x => x > parameter)
                .Cast<string>()
                .ToList();
        }

        public List<string> ValueSmallerThan(string attribute, string value)
        {
            List<int> list = _fileParser.ParseFile(attribute).Cast<int>().ToList();
            int parameter = int.Parse(value);

            return list.Where(x => x < parameter)
                .Cast<string>()
                .ToList();
        }

        public List<string> ValueEquals(string attribute, string value)
        {
            List<string> list = _fileParser.ParseFile(attribute);

            return list.Where((x) => x.Equals(value))
                .ToList();
        }

    }
}
