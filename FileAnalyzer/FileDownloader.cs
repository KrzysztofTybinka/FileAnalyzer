using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for 
    /// downloading file content.
    /// </summary>
    public class FileDownloader
    {
        /// <summary>
        /// Gets string representation of file content.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>String representation of file content.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetContent(string input)
        {
            if (IsUrl(input))
            {
                return DownloadFromUrl(input).Result;
            }
            else if (IsValidPath(input))
            {
                return DownloadFromDir(input);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Checks if input value is url address.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input walue is url, otherwise false.</returns>
        /// <exception cref="NullReferenceException"></exception>
        private bool IsUrl(string input)
        {
            return Uri.TryCreate(input, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == (Uri.UriSchemeHttp ?? throw new NullReferenceException())
                || uriResult.Scheme == (Uri.UriSchemeHttps ?? throw new NullReferenceException()));
        }

        /// <summary>
        /// Checks if input value is 
        /// valid directory path.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is valid, otherwise false.</returns>
        private bool IsValidPath(string input)
        {
            return File.Exists(input);
        }

        /// <summary>
        /// Downloads file as a string from given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>File content as a string.</returns>
        private async Task<string> DownloadFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        /// <summary>
        /// Downloads file as a string from specified directory.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>File content as a string.</returns>
        private string DownloadFromDir(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
