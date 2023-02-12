using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    /// <summary>
    /// Provides methods for downloading files.
    /// </summary>
    public class FileDownloader
    {
        public string Download(string input)
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

        private bool IsUrl(string input)
        {
            return Uri.TryCreate(input, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == (Uri.UriSchemeHttp ?? throw new NullReferenceException())
                || uriResult.Scheme == (Uri.UriSchemeHttps ?? throw new NullReferenceException()));
        }

        private bool IsValidPath(string input)
        {
            return File.Exists(input);
        }

        private async Task<string> DownloadFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        private string DownloadFromDir(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
