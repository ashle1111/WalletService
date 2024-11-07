using System.Text;
using Newtonsoft.Json;

namespace WalletService
{
    public class BalanceResponse
    {
        public int Amount { get; set; }
    }

    public class ApiTests : BaseURL
    {
        private async Task<BalanceResponse> GetBalanceAsync()
        {
            var response = await Client.GetAsync("/onlinewallet/balance");
            response.EnsureSuccessStatusCode();
            var balanceContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BalanceResponse>(balanceContent);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string endpoint, object payload)
        {
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            return await Client.PostAsync(endpoint, content);
        }

        [Fact]
        public async Task GetBalance_ShouldReturnCurrentBalance()
        {
            var balanceResponse = await GetBalanceAsync();
            Assert.Equal(0, balanceResponse.Amount);
        }

        [Fact]
        public async Task Deposit_ShouldIncreaseBalance()
        {
            await SendRequestAsync("/onlinewallet/deposit", new { Amount = 200 });
            var balanceResponse = await GetBalanceAsync();
            Assert.Equal(200, balanceResponse.Amount);
        }
    }
}
