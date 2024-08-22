namespace AsyncProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var th = new Thread(() => Display("A Thread"));
            //th.Start();
            //th.Join();

            //Task.Run(() => Display("A Task")).Wait();


            Task<DateTime> tsk = Task.Run(() => DateTime.Now);
            tsk.Wait();

            //Console.WriteLine(tsk.Result); // thread block

            Console.WriteLine(tsk.GetAwaiter().GetResult());

            Console.ReadKey();
        }

        static void Display(string message)
        {
            ShowInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        static void ShowInfo(Thread th)
        {
            Console.WriteLine($"ID : {th.ManagedThreadId}, Pool : {th.IsThreadPoolThread}, BackGround : {th.IsBackground}");
        }
    }
}
