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

        public List<int> ValueGreaterThan(string attribute)
        {
            List<int> list = _fileParser.ParseFile(attribute).Cast<int>().ToList();

            list = list.Select()
        }

        private List<T> ValuesToList<T>(string attribute)
        {
            throw new NotImplementedException();
        }
    }
}
