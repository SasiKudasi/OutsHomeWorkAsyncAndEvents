using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class ImageDownloader
    {
        public event Action<string, string>? ImageStarted;
        public event Action<string, string>? ImageCompleted;

        public string Url { get; set; }
        public string FileName { get; set; }
        public ImageDownloader(string url, string fileName)
        {
            this.Url = url;
            this.FileName = fileName;
        }

        public async Task Download()
        {
            using (var myWebClient = new WebClient())
            {
                this.ImageStarted?.Invoke(this.FileName, this.Url);
                await myWebClient.DownloadFileTaskAsync(Url, FileName);
                this.ImageCompleted?.Invoke(this.FileName, this.Url);
            }

        }
    }

}
