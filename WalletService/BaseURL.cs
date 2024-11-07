namespace WalletService
{
    public class BaseURL
    {
        protected readonly HttpClient Client;

        public BaseURL()
        {
            Client = new HttpClient { BaseAddress = new Uri("http://localhost:5047") };
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
