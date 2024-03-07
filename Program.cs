﻿using System.Net;
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
            Task res = null;
            for (int i = 0; i < 10; i++)
            {
                var download = new ImageDownloader(remoteUri, $"{fileName}{i}.jpg");
                var startSender = new Subsriber();
                startSender.ImageStarted(download);
                startSender.ImageCompleted(download);
                res = download.Download();
                tasks.Add(res);

            }
            ConsoleKeyInfo key = Console.ReadKey();
            TaskIsComplited(tasks, key);
        }

        static void TaskIsComplited(List<Task> values, ConsoleKeyInfo key)
        {
            var cts = new CancellationTokenSource();
            while (true)
            {
                key = Console.ReadKey();
                Console.WriteLine("Нажмите \"A\" для выхода");

                if (key.KeyChar == 'A')
                {
                    Environment.Exit(0);
                }
                else
                {
                    foreach (Task task in values)
                    {
                        Console.WriteLine($"Выполнение загрузки картинки {task.Id}: {task.IsCompleted}");
                        if (cts.IsCancellationRequested)
                        {
                            cts.Cancel();
                        }

                    }
                }

            }
        }


    }
}