using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    internal class ImageDownloader
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
            FileName += ".jpg";
            var myWebClient = new WebClient();
            this.ImageStarted?.Invoke(this.FileName, this.Url);
            await myWebClient.DownloadFileTaskAsync(Url, FileName);
            this.ImageCompleted?.Invoke(this.FileName, this.Url);
        }
    }
    class Subsriber
    {
        public void ImageStarted(ImageDownloader imageDownloader)
        {
            imageDownloader.ImageStarted += (string fileName, string url) =>
            {
                Console.WriteLine($"Качаю \"{fileName}\" из \"{url}\" .......\n\n");
            };
        }

        public void ImageCompleted(ImageDownloader imageDownloader)
        {
            imageDownloader.ImageCompleted += (string fileName, string url) =>
            {
                Console.WriteLine($"Успешно скачал \"{fileName}\" из \"{url}\" .......\n\n");
            };
        }
    }
}
