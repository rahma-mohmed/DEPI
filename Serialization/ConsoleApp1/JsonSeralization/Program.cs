using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSeralization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee
            {
                Id = 1,
                Fname = "Rahma",
                Lname = "Abo Shaheen",
                Benefits = { "Pension", "Health Insurance" }
            };

            var content = SeralizeToJsonStringUsingJsonNet(e1);
            Console.WriteLine(content);

            Employee e2 = DeSeralizeFromJsonStringUsingNewtonSoft(content);
            //Console.WriteLine(e2.Fname);
        }

        static string SeralizeToJsonStringUsingNewtonSoft(Employee employee)
        {
            var result = "";
            result = JsonConvert.SerializeObject(employee , Formatting.Indented);
            return result;
        }

        static Employee DeSeralizeFromJsonStringUsingNewtonSoft(string jsonContent)
        {
            Employee employee = null;
            employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
            return employee;
        }

        static string SeralizeToJsonStringUsingJsonNet(Employee employee)
        {
            var result = "";
            result = System.Text.Json.JsonSerializer.Serialize(employee,
                new JsonSerializerOptions { WriteIndented = true });
            return result;
        }

        static Employee DeSeralizeFromJsonStringUsingJsonNett(string jsonContent)
        {
            Employee employee = null;
            employee = System.Text.Json.JsonSerializer.Deserialize<Employee>(jsonContent);
            return employee;
        }
    }
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }

        [NonSerialized]
        public string Lname;
        public List<string> Benefits { get; set; } = new List<string>();
    }
}
