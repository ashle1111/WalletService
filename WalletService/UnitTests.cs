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

        // Deducts a specified amount from the wallet balance if sufficient funds are available 
        // and the amount is greater than zero.
        // Parameters:
        //     amount: The amount to withdraw from the balance.
        // Returns:
        //     True if the withdrawal is successful; otherwise, false.
        public bool Withdraw(decimal amount)
        {
            // Ensure withdrawal amount is positive and does not exceed the current balance.
            if (amount > _balance || amount <= 0) return false;

            // Decrease the balance by the withdrawal amount.
            _balance -= amount;
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


        [Fact]
        public void Withdraw_WithSufficientFunds_ShouldSubtractFromBalance()
        {
            // Arrange: Initialize WalletService and deposit an amount greater than the withdrawal amount.
            var walletService = new WalletService();
            walletService.Deposit(200);

            // Act: Withdraw a specified amount from the wallet.
            var result = walletService.Withdraw(100);

            // Assert: Verify the withdrawal was successful and the balance is reduced accordingly.
            Assert.True(result);
            Assert.Equal(100, walletService.GetBalance());
        }

        [Fact]
        public void Withdraw_WithInsufficientFunds_ShouldReturnFalse()
        {
            // Arrange: Initialize WalletService and deposit an amount less than the withdrawal amount.
            var walletService = new WalletService();
            walletService.Deposit(50);

            // Act: Attempt to withdraw more than the available balance.
            var result = walletService.Withdraw(100);

            // Assert: Verify the withdrawal failed and the balance remains unchanged.
            Assert.False(result);
            Assert.Equal(50, walletService.GetBalance());
        }

        [Fact]
        public void FinalBalance_ShouldReturnFinalBalanceAfterVariousTransactions()
        {
            // Arrange: Initialize WalletService and perform a series of transactions.
            var walletService = new WalletService();
            walletService.Deposit(200);    // Deposit 200
            walletService.Withdraw(100);   // Withdraw 100
            walletService.Deposit(50);     // Deposit 50

            // Act: Retrieve the final balance after all transactions.
            var balance = walletService.GetBalance();

            // Assert: Verify the final balance is correct after the series of transactions.
            Assert.Equal(150, balance);
        }

    }
}