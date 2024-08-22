using System.Text.Json;

namespace HTTPClientJson
{
    internal class Program
    {
        private readonly static HttpClient _httpClient = new HttpClient();
        
        static async Task Main(string[] args)
        {
            var todos = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            var li = JsonSerializer.Deserialize<List<Todo>>(todos , new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            foreach (var x in li) {
                Console.WriteLine(x);
            }
        }
    }


    public class Todo
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"({userId}) {Title} : {(Completed ? "Completed" : "Not Comleted")}";
        }
    }

}
