namespace CADisposableDesingPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*CurrencyService currencyService = null;
            try
            {
                currencyService = new CurrencyService();
                var res = currencyService.GetCoins();
                Console.WriteLine(res);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                currencyService?.Dispose();
            }
            Console.ReadKey();*/

            //using call dispose by default
            using (CurrencyService currencyService = new CurrencyService())
            {
                var res = currencyService.GetCoins();
                Console.WriteLine(res);
            }

            Console.ReadKey();
        }
    }

    class CurrencyService : IDisposable
    {
        //unmanaged => clean
        private readonly HttpClient _httpClient;
        private bool _disposed = false;

        public CurrencyService()
        {
            _httpClient = new HttpClient();
        }

        ~CurrencyService()
        {
            Dispose(false);
        }

        //public
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //private => class , any person inherit
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _httpClient.Dispose();
            }
            _disposed = true;
        }

        public string GetCoins()
        {
            string url = "https://coinbase.com/api/v2/currencies";
            var res = _httpClient.GetStringAsync(url).Result;
            return res;
        }
    }
}
