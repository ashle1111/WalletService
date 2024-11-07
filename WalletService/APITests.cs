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

        [Fact]
        public async Task GetBalance_ShouldReturnCurrentBalance()
        {
            var balanceResponse = await GetBalanceAsync();
            Assert.Equal(0, balanceResponse.Amount);
        }
    }
}
