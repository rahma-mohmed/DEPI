namespace HttpWebRequst_Response
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            WebServiceConsumer.ConsumeWebService(url);

            Task<string> t1 = Task<string>.Run(() => DateTime.Now.DayOfWeek.ToString());
            Console.WriteLine(t1.Result);
        }
    }
}
