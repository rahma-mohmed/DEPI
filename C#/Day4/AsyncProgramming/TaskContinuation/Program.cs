using System.Threading.Channels;

namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> res = Task.Run(() => CountPrime(2, 3_000_000));

            /*Console.WriteLine(res.Result);
            Console.WriteLine("Task is completed");*/

            //------------------------------------------------
            //var awaiter = res.GetAwaiter();
            //awaiter.OnCompleted(() => {
            //    Console.WriteLine(awaiter.GetResult());
            //    }
            //);

            //-------------------------------------------------
            //res.ContinueWith(x => Console.WriteLine(x.Result));
            //Console.WriteLine("Task is completed");

            //-------------------------------------------------

            DelayUsingTask(3000);
            Console.ReadKey();
        }

        static int CountPrime(int l, int u)
        {
            var c = 0;

            for (var i = l; i < u; i++)
            {
                var j = l;
                var isPrime = true;

                while (j <= Math.Sqrt(l))
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }

                if (isPrime)
                {
                    c++;
                }
            }
            return c;
        }

        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed Task after {ms}");
            });
        }
    }
}
