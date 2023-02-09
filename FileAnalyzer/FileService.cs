using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for querying
    /// file data.
    /// </summary>
    public class FileService
    {
        private IFileParser _fileParser;

        public FileService(IFileParser fileParser)
        {
            _fileParser = fileParser;
        }

        /// <summary>
        /// Queries file values greater than given number.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns>List of numbers greater than given value.</returns>
        public List<string?> ValueGreaterThan(string attribute, string value)
        {
            int parameter = int.Parse(value);

            return _fileParser
                .ParseFile(attribute)
                .Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)
                .Where(x => x > parameter)
                .ToList()
                .ConvertAll(x => x.ToString());
        }

        /// <summary>
        /// Queries file values smaller than given number.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns>List of numbers smaller than given value.</returns>
        public List<string?> ValueSmallerThan(string attribute, string value)
        {
            int parameter = int.Parse(value);

            return _fileParser
                .ParseFile(attribute)
                .Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)
                .Where(x => x < parameter)
                .ToList()
                .ConvertAll(x => x.ToString());
        }

        /// <summary>
        /// Queries file values that are equal to given value.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns>List of values equal to given value parameter.</returns>
        public List<string?> ValueEquals(string attribute, string value)
        {
            List<string?> list = _fileParser.ParseFile(attribute);

            return list.Where((x) => x.Equals(value))
                .ToList();
        }

    }
}
