using System.Net;
using System.Threading;

namespace HW6
{
    internal class Program
    {
        private List<Task> _tasks = new List<Task>();
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            string remoteUri = "https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg";
            string fileName = "bigimage";
            var cts = new CancellationTokenSource();
            for (int i = 0; i < 10; i++)
            {
                var download = new ImageDownloader(remoteUri, $"{fileName}{i}.jpg");
                var startSender = new Subsriber();
                startSender.ImageStarted(download);
                startSender.ImageCompleted(download);
                tasks.Add(download.Download(cts.Token));
            }
            ConsoleKeyInfo key = Console.ReadKey();
            TaskIsComplited(tasks, key, cts);


        }

        static void TaskIsComplited(List<Task> values, ConsoleKeyInfo key, CancellationTokenSource cancellationToken)
        {            
            while (!cancellationToken.IsCancellationRequested)
            {
                key = Console.ReadKey();
                Console.WriteLine("Нажмите \"A\" для выхода");

                if (key.KeyChar == 'A')
                {
                    cancellationToken.Cancel();                    
                }
                else
                {
                    foreach (Task task in values)
                    {
                        Console.WriteLine($"Выполнение загрузки картинки {task.Id}: {task.IsCompleted}");
                    }
                }
            }
        }


    }
}