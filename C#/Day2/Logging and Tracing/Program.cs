using System.Diagnostics;
namespace Logging_and_Tracing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));

            Trace.WriteLine("Application Started");

            try
            {
                var std = GetStudent();
                Trace.WriteLine($"Number of students: {std.Count}");
            }
            catch (Exception ex)
            {
                Trace.TraceError("An error occurred: " + ex.Message);
            }
            finally 
            {
                Trace.WriteLine("Application ended.");
                Trace.Flush();
            }
        }

        static List<string> GetStudent()
        {
            return new List<string> { "Alice", "Bob" };
        }
    }
}
