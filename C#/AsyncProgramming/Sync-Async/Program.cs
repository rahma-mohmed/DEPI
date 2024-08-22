namespace Sync_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*ShowInfo(7 , Thread.CurrentThread);
            CallSync();

            ShowInfo(10, Thread.CurrentThread);
            CallASync();

            ShowInfo(13, Thread.CurrentThread);
            Console.ReadKey();*/
            //--------------------------------------------------------

            /*var task = Task.Run(() => ReadContent("https://jsonplaceholder.typicode.com/todos"));
            var aw = task.GetAwaiter();
            aw.OnCompleted(() => Console.WriteLine(aw.GetResult()));
            Console.ReadKey();*/

            //--------------------------------------------------------

            //var content = await ReadContentAsync("https://jsonplaceholder.typicode.com/todos");
            //Console.WriteLine(content);
            //Console.ReadKey();
        }

        static void CallSync()
        {
            Thread.Sleep(4000);
            ShowInfo(20 , Thread.CurrentThread);
            Task.Run(() => Console.WriteLine("+++++++++++ Synchronous +++++++++++")).Wait();
        }

        static void CallASync()
        {

            ShowInfo(27 , Thread.CurrentThread);
            Task.Delay(4000).GetAwaiter().OnCompleted(() => {
                ShowInfo(29 , Thread.CurrentThread);
                Console.WriteLine("+++++++++++ ASynchronous +++++++++++");
            });
        }

        private static void ShowInfo(int line ,Thread th )
        {
            Console.WriteLine($"Line : {line} ,ID : {th.ManagedThreadId}, Pool : {th.IsThreadPoolThread}, BackGround : {th.IsBackground}");
        }

        static Task<string> ReadContent(string url)
        {
            var c = new HttpClient();
            var task = c.GetStringAsync(url);
            return task;
        }

        static async Task<string> ReadContentAsync(string url)
        {
            var c = new HttpClient();
            var content = await c.GetStringAsync(url);
            return content;
        }
    }
}
