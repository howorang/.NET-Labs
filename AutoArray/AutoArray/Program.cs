using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoArray
{
    class Program
    {
        static AutoArray array = new AutoArray();

        public static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(nonBlockingRunnable);
                thread.Name = "Nonblocking " + i;
                threads.Add(thread);
            }

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(blockingRunnable);
                thread.Name = "BLocking " + i;
                threads.Add(thread);
            }

            Shuffle(threads);

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Finished");

            IList<String> lines = array.ToLines();
            File.WriteAllLines("list.txt", lines);

            Console.ReadKey();
        }

        public static void nonBlockingRunnable()
        {
            String name = Thread.CurrentThread.Name;
            for (int i = 0; i < 50; i++)
            {
                if (!array.TryAdd(name))
                {
                   Console.WriteLine("Access denied to: {0}", name); 
                }
            }
        }

        public static void blockingRunnable()
        {
            String name = Thread.CurrentThread.Name;
            for (int i = 0; i < 50; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                array.Add(name);
                stopwatch.Stop();
                long elapsedTime = stopwatch.ElapsedMilliseconds;
                Console.WriteLine("Thread {0} Time elapsed: {1}", name, elapsedTime);
            }
        }

        private static Random rng = new Random();

        public static IList<T> Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }

}
