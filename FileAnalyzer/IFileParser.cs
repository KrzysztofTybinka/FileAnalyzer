using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for file parsing.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Gets file from directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String representation of file content.</returns>
        public string GetFile(string path);

        /// <summary>
        /// Parses given attribute values from file into string list.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>List with parsed attribute values.</returns>
        public List<string?> ParseFile(string attribute);
    }
}
