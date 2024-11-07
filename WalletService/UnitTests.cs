namespace WalletService
{
    // WalletService class provides functionality for managing a wallet balance,
    // including methods for retrieving balance, depositing funds, and withdrawing funds.
    public class WalletService
    {
        // Stores the current balance of the wallet.
        private decimal _balance;

        // Retrieves the current balance in the wallet.
        // Returns:
        //     The current balance as a decimal.
        public decimal GetBalance()
        {
            return _balance;
        }

        // Adds a specified amount to the wallet balance if the amount is greater than zero.
        // Parameters:
        //     amount: The amount to add to the balance.
        // Returns:
        //     True if the deposit is successful; otherwise, false.
        public bool Deposit(decimal amount)
        {
            // Ensure the deposit amount is positive.
            if (amount <= 0) return false;

            // Increase the balance by the deposit amount.
            _balance += amount;
            return true;
        }

    }

    // UnitTests class contains test methods to validate the functionality of WalletService.
    public class UnitTests
    {
        [Fact]
        public void GetBalance_ShouldReturnCurrentBalance()
        {
            // Arrange: Initialize a new WalletService instance and deposit an initial amount.
            var walletService = new WalletService();
            walletService.Deposit(100);

            // Act: Retrieve the current balance.
            var balance = walletService.GetBalance();

            // Assert: Verify the balance matches the deposited amount.
            Assert.Equal(100, balance);
        }

        [Fact]
        public void Deposit_ShouldAddFundsToBalance()
        {
            // Arrange: Initialize a new WalletService instance.
            var walletService = new WalletService();

            // Act: Deposit a specified amount into the wallet.
            walletService.Deposit(200);

            // Assert: Verify the balance is updated to reflect the deposit.
            Assert.Equal(200, walletService.GetBalance());
        }

    }
}