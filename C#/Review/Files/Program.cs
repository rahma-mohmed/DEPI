namespace Files
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string sourceDirectory = @"D:\DEPI\C#\Review\Files\Dir1";
            string outputFilePath = @"D:\DEPI\C#\Review\Files\Output.txt";

            CombineFiles(sourceDirectory, outputFilePath);
        }

        static void CombineFiles(string sourceDirectory, string outputFilePath)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Source directory does not exist.");
                return;
            }

            string[] files = Directory.GetFiles(sourceDirectory , "*.txt");

            if (files.Length == 0) {
                Console.WriteLine("No text files found in the source directory.");
                return;
            }

            string combinedContent = "";

            foreach (string file in files)
            {
                try
                {
                    string content = File.ReadAllText(file);
                    combinedContent += content + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    {
                        Console.WriteLine($"Error reading file {file}: {ex.Message}");
                    }
                }

            }

            try
            {
                File.WriteAllText(outputFilePath , combinedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file {outputFilePath}: {ex.Message}");
            }
        }
    }
}
