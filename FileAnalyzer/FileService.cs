using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
