using System.Net.Http;

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

        public async Task Download(CancellationToken cancellationToken)
        {
            ImageStarted?.Invoke(FileName, Url);
            await Task.Run(async () =>
            {
                using (var myWebClient = new HttpClient())
                {
                    using (var response = await myWebClient.GetAsync(Url, cancellationToken))
                    {
                        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
                        await File.WriteAllBytesAsync(FileName, bytes, cancellationToken);
                    }
                    ImageCompleted?.Invoke(FileName, Url);
                }
            }, cancellationToken);



        }
    }

}
