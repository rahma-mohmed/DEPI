namespace CustomException
{
    public class CustomException : Exception
    {
        public CustomException() : base()
        {
            
        }

        public CustomException(string message) :base(message)
        {
            
        }

        public CustomException(string message , Exception inner) : base(message, inner) 
        {
            
        }
        public int ErrorCode { get;set; }
        public override string ToString()
        {
            return $"{base.ToString()},Error code: {ErrorCode}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new CustomException("A custom error occurred", new InvalidOperationException())
                {
                    ErrorCode = 222
                };
            }
            catch (CustomException ex) {
                Console.WriteLine($"Exception caught: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Error Code: {ex.ErrorCode}");
                Console.WriteLine($"Exception Details: {ex.ToString()}");
            } 
        }
    }
}
