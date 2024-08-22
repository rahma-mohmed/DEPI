using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee{
                Id = 1,
                Fname = "Rahma",
                Lname = "Abo Shaheen",
                Benefits = { "Pension", "Health Insurance" }
            };

            string xmlcontent = GetXmlcontent(e1);
            File.WriteAllText("xmlSerialization.xml" , xmlcontent);

            Employee e2 = DeseralizeFromXML(xmlcontent);
            Console.WriteLine(e2.Fname);

            Console.ReadKey();
        }

        private static Employee DeseralizeFromXML(string xmlcontent)
        {
            Employee employee = null;
            var xmlSerializer = new XmlSerializer(typeof(Employee));

            using (TextReader r = new StringReader(xmlcontent))
            {
                employee = xmlSerializer.Deserialize(r) as Employee;
            }
            return employee;
        }

        private static string GetXmlcontent(Employee e1)
        {
            var res = "";

            var xmlselizer = new XmlSerializer(e1.GetType());

            using (var sw = new StringWriter()) {
                using (var wr = XmlTextWriter.Create(sw, new XmlWriterSettings { Indent = true }))
                {
                    xmlselizer.Serialize(wr, e1);
                    res = sw.ToString();
                }
            }
            return res;
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
