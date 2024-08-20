namespace CAFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method02();
            Console.ReadKey();
        }

        static void Method01()
        {
            string path = "D:\\DEPI\\FileStream\\IOStream\\users.csv";

            using (FileStream fs = new FileStream(path, FileMode.Open , FileAccess.ReadWrite))
            {
                byte[] data = new byte[fs.Length];

                int numBytesToRead = (int) fs.Length;
                int numBytesRead = 0;

                while (numBytesToRead > 0) { 
                    int n = fs.Read(data, numBytesRead, numBytesToRead);

                    if(n == 0)
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
    }
}
