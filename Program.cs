using System;
using System.Text;
using System.Threading;

namespace TaskQueueSemaphore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int totalThread = 10;
            Thread[] threads = new Thread[totalThread];

            for (int i = 0; i < totalThread; i++)
            {
                int id = i+1;
                threads[i] = new Thread(() => TaskQueue.RunTask(id));
                threads[i].Start();
            }
            foreach(var th in threads)
            {
                th.Join();
            }
            Console.WriteLine("\n========================================");
            Console.WriteLine("Задачи выполнены");
            Console.WriteLine("Семафор отработал");
            Console.WriteLine("========================================");
        }
    }
}
