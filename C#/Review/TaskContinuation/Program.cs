namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() => {
                Console.WriteLine("Calculating sum...");
                int s = 0;
                for (int i = 1; i <= 200; i++) {
                    s += i;
                }
                return s;
            });

            Task continuationTask = task.ContinueWith(task =>
            {
                Console.WriteLine($"Continuation Task: The sum is {task.Result}");
            });

            continuationTask.Wait();
            Console.WriteLine("Completed");


            Task parent = Task.Run(() => {
                Console.WriteLine("Parent Task: Starting nested task...");

                Task nested = Task.Run(() => {
                    Console.WriteLine("Nested Task: Executing...");
                });

                nested.Wait();
                Console.WriteLine("Parent Task: Nested task completed.");
            });

            parent.Wait();
            Console.WriteLine("All tasks completed.");
        }
    }
}
