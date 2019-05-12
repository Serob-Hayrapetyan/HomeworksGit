using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment8
{
    class MyParallel
    {
        /// <summary>
        /// My own ForLoop
        /// </summary>
        /// <param name="fromInclusive"></param>
        /// <param name="toExclusive"></param>
        /// <param name="body"></param>
        public static void ParallelFor(int fromInclusive, int toExclusive, Action<int> body)
        {
            for (; fromInclusive < toExclusive; fromInclusive++)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    body(fromInclusive);
                });
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// My own ForEachLoop
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        public static void ParallelForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
        {
            foreach (var x in source)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    body(x);
                });
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// My own ForEachLoopWithOptions5
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="parallelOptions"></param>
        /// <param name="body"></param>
        public static void ParallelForEachWithOptions<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
        {
            int maxDeg = parallelOptions.MaxDegreeOfParallelism;
            if (Environment.ProcessorCount <= maxDeg)
            {
                ThreadPool.SetMaxThreads(maxDeg, 10);
                foreach (var x in source)
                {
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        body(x);
                    });
                    Thread.Sleep(10);
                }
            }
            else
            {
                Console.WriteLine("You have more processors than your thread's count");
            }
        }

    }
}
