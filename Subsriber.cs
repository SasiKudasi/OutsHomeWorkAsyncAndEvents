using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class Subsriber
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
