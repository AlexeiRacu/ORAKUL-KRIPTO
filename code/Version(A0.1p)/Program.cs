using CoinGeckoAPI;
using Newtonsoft.Json.Linq;
namespace ORAKUL_KRYPTO
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string cryptoCurrency = "bitcoin";

            while (true)
            {
                await GetCryptoPrice(cryptoCurrency);
                Thread.Sleep(10000);
            }
        }

        private static async Task GetCryptoPrice(string crypto)
        {
            try
            {
                string url = $"https://api.coingecko.com/api/v3/simple/price?ids={crypto}&vs_currencies=usd";
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);

                decimal price = json[crypto]["usd"].Value<decimal>();
                Console.WriteLine($"Current price of {crypto} in USD: {price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
