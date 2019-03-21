using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TplPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // A: Tasks can be created to just run basic functions.
            Task ta = Task.Run(() => Console.WriteLine("(A) Hello World (A)"));
            // That task can then be awaited.
            await ta;

            // B: Does that task start before I await it?
            Task tb = Task.Run(() => Console.WriteLine("(B) Hello World (B)"));
            await Task.Delay(50);
            Console.WriteLine("(B') Hello World (B')");
            await tb;
            // Output: 
            // Hello World (B)
            // Hello World (B')
            // Answer, yes it does.

            // C: TaskFactor.StartNew()
            List<Task> tc = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tc.Add(Task.Factory.StartNew((Object obj) =>
                {
                    TaskCData d = obj as TaskCData;
                    if (d == null)
                        return;
                    var seed = (int)(DateTime.Now.Ticks % i * i);
                    d.Seed = seed;
                    d.Rand = new Random(seed).Next();
                }, new TaskCData { Time = i, Rand = 0 }));
            }
            Task.WaitAll(tc.ToArray());
            foreach (var item in tc)
            {
                var d = item.AsyncState as TaskCData;
                if (d != null)
                {
                    Console.WriteLine("(C) Hello world from {0}:{2} with #{1}", d.Time, d.Rand, d.Seed);
                }
            }

            // D: Task<Result> is used commonly in MVC and I've used it a lot.  Nothing particular to note here.
            Task<int> td = Task<int>.Factory.StartNew(() =>
            {
                return 7;
            });
            Console.WriteLine("(D) Hello World with {0}", await td);

            // E: Continuations.  Tasks can be continued with callback functions.
            var te = Task.Factory.StartNew(() =>
            {
                Random r = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute);
                int[] data = new int[20];
                for (int i = 0; i < data.Length; i++)
                    data[i] = r.Next();

                return data;
            });
            var run = te.ContinueWith((data) =>
            {
                int[] items = data.Result;
                long sum = 0;
                decimal avg = 0M;
                for (int i = 0; i < items.Length; i++)
                    sum += items[i];
                avg = sum / (decimal)items.Length;
                return (items.Length, sum, avg);
            });
            var teResults = run.ContinueWith((res) => {
                var d = res.Result;
                return String.Format("(E) Length={0}; Avg={1}; Sum={2}", d.Length, d.avg, d.sum);
            });
            Console.WriteLine(await teResults);


            Console.WriteLine("Hello World!");
        }
    }

    public class TaskCData
    {
        public long Time { get; set; }
        public int Rand { get; set; }
        public int Seed { get; set; }
    }
}



