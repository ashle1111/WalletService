using System.Text;
using Newtonsoft.Json;

namespace WalletService
{
    // Represents the response format for the balance API.
    public class BalanceResponse
    {
        // Property for the current balance amount.
        public int Amount { get; set; }
    }

    // Contains unit tests for the wallet service API endpoints.
    public class ApiTests : BaseURL
    {
        // Retrieves the current balance from the /balance endpoint.
        // Returns:
        //     A BalanceResponse object containing the current balance amount.
        private async Task<BalanceResponse> GetBalanceAsync()
        {
            // Send a GET request to the balance endpoint.
            var response = await Client.GetAsync("/onlinewallet/balance");

            // Ensure the response is successful.
            response.EnsureSuccessStatusCode();

            // Read the balance content as a string.
            var balanceContent = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string into a BalanceResponse object and return it.
            return JsonConvert.DeserializeObject<BalanceResponse>(balanceContent);
        }

        // Sends a POST request with a JSON payload to a specified endpoint.
        // Parameters:
        //     endpoint: The API endpoint to send the request.
        //     payload: The JSON payload to send in the request body.
        // Returns:
        //     The HttpResponseMessage returned by the API.
        private async Task<HttpResponseMessage> SendRequestAsync(string endpoint, object payload)
        {
            // Serialize the payload to JSON and create the request content.
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            // Send the POST request to the specified endpoint with the content.
            return await Client.PostAsync(endpoint, content);
        }

        // Test method to verify that the GetBalance API returns the correct current balance.
        [Fact]
        public async Task Two_GetBalance_ShouldReturnCurrentBalance()
        {
            // Act: Retrieve the current balance by calling the GetBalanceAsync helper method.
            var balanceResponse = await GetBalanceAsync();

            // Assert: Verify that the balance amount matches the expected value of 0.
            Assert.Equal(0, balanceResponse.Amount);
        }

        // Test method to verify that making a deposit increases the balance correctly.
        [Fact]
        public async Task One_Deposit_ShouldIncreaseBalance()
        {
            // Arrange: Deposit an amount of 200 by calling the SendRequestAsync helper method.
            await SendRequestAsync("/onlinewallet/deposit", new { Amount = 200 });

            // Act: Retrieve the updated balance after deposit.
            var balanceResponse = await GetBalanceAsync();

            // Assert: Verify that the balance amount is now 200, indicating the deposit was successful.
            Assert.Equal(200, balanceResponse.Amount);
        }

        // Test method to verify that making a withdrawal decreases the balance correctly.
        [Fact]
        public async Task First_Withdraw_ShouldDecreaseBalance()
        {
            // Arrange: Withdraw an amount of 200 by calling the SendRequestAsync helper method.
            await SendRequestAsync("/onlinewallet/withdraw", new { Amount = 200 });

            // Act: Retrieve the updated balance after withdrawal.
            var balanceResponse = await GetBalanceAsync();

            // Assert: Verify that the balance amount is now 0, indicating the withdrawal was successful.
            Assert.Equal(0, balanceResponse.Amount);
        }
    }
}
