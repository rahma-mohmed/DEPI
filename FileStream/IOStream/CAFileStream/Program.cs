namespace CAFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method08();
            Console.ReadKey();
        }

        static void Method01()
        {
            string path = "D:\\DEPI\\FileStream\\IOStream\\users.csv";

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] data = new byte[fs.Length];

                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fs.Read(data, numBytesRead, numBytesToRead);

                    if (n == 0)
                    {
                        break;
                    }
                    numBytesToRead -= n;
                    numBytesRead += n;
                }

                foreach (byte b in data)
                {
                    Console.WriteLine(b);
                }
            }
        }

        static void Method02()
        {
            var path2 = "D:\\DEPI\\FileStream\\IOStream\\t1.txt";

            using (var fs2 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs2.Seek(10, SeekOrigin.Begin);
                fs2.WriteByte(65);
                fs2.Position = 0;

                for (int i = 0; i < fs2.Length; i++)
                {
                    Console.WriteLine(fs2.ReadByte());
                }
            }
        }


        static void Method03()
        {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t2.txt";

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("This Is C#");
            }
        }

        static void Method04()
        {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t2.txt";

            using(var sr = new StreamReader(path))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    Console.Write(line);
                }
            }
        }

        static void Method05()
        {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t3.txt";

            string[] lines =
            {
                "Hello",
                "My",
                "Friends"
            };

            File.WriteAllLines(path, lines);
        }

        static void Method06()
        {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t4.txt";

            string txt = "Hello My Friends welcome to my GitHub account";

            File.WriteAllText(path, txt);
        }

        static void Method07()
        {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t4.txt";

            var res = File.ReadAllText(path);

            Console.WriteLine(res);
        }

        static void Method08() {
            var path = "D:\\DEPI\\FileStream\\IOStream\\t4.txt";

            var res = File.ReadAllLines(path);

            foreach(var line in res)
            {
                Console.Write(line);
            }
        }
    }
}
