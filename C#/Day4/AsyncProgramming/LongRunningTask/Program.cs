namespace LongRunningTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Task.Factory.StartNew(() => RunLong() , TaskCreationOptions.LongRunning);

            //2
            var th = new Thread(() => ThrowException());
            th.Start();
            th.Join();

            //3
            try
            {
                Task.Run(ThrowExceptionUsingTask).Wait();
            }
            catch
            {
                Console.WriteLine("Exception throw");
            }
        }

        static void ShowInfo(Thread th)
        {
            Console.WriteLine($"ID : {th.ManagedThreadId}, Pool : {th.IsThreadPoolThread}, BackGround : {th.IsBackground}");
        }

        static void RunLong()
        {
            Thread.Sleep(3000);
            ShowInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }

        static void ThrowException()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch
            {
                Console.WriteLine("Exception throw");
            }
        }

        static void ThrowExceptionUsingTask()
        {
            
             throw new NullReferenceException();
        }
    }
}
