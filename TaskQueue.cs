using System;
using System.Threading;

namespace TaskQueueSemaphore
{
    public class TaskQueue
    {
        private static readonly Semaphore semaphore = new Semaphore(2, 2);

        public static void RunTask(int taskId)
        {
            Console.WriteLine($" Поток #{taskId} перед началом старта, ждет пропуск...");

            semaphore.WaitOne();
            try
            {
                Console.WriteLine($"  >>> Поток № [{taskId}] работтает. Время: {DateTime.Now:ss.ff}");
                Thread.Sleep(2000);                
                Console.WriteLine($"   <<< Поток № [{taskId}] завершил ");
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine($"   <<< Поток № [{taskId}] вернул пропуск ");
            }


        }

    }
}
