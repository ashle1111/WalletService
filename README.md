# Wallet Service

## There are three API tests:
- Get Balance
- Deposit
- Withdraw

As the API tests have dependencies, they are prefixed with First, One, and Two. This ensures that the tests run sequentially, allowing them to pass consistently.

## There are five unit tests:
- Get Balance
- Deposit
- Withdraw with Sufficient Funds
- Withdraw with Insufficient Funds
- Final Balance 


**When you execute the tests, Please keep opeining http://localhost:5047/swagger/index.html (Swagger) in browser**