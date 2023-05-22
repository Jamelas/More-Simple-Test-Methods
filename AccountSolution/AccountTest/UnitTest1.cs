using AccountLibrary;
namespace AccountTest

{
    [TestClass]
    public class UnitTest1
    {
        private Account objAccount;

        [TestInitialize]
        public void TestInitialize()
        {
            objAccount = new Account(1000, 500);
        }

        [TestMethod]
        public void TestMethodDeposit()
        {
            objAccount.Deposit(200);
            Assert.AreEqual(1200, objAccount.Balance);
            Assert.AreEqual(AccountState.Safe, objAccount.State);
        }

        [TestMethod]
        public void TestMethodWithdraw()
        {
            objAccount.Withdraw(200);
            Assert.AreEqual(800, objAccount.Balance);
            Assert.AreEqual(AccountState.Safe, objAccount.State);
        }

        [TestMethod]
        public void TestMethodWithdrawAndDeposit()
        {
            objAccount.Withdraw(200);
            objAccount.Deposit(600);
            objAccount.Withdraw(100);
            Assert.AreEqual(1300, objAccount.Balance);
            Assert.AreEqual(AccountState.Safe, objAccount.State);
        }

        [TestMethod]//, ExpectedException(typeof(ArgumentException))]
        public void TestMethodWithdrawNegative()
        {
            objAccount.Withdraw(-200);
            Assert.AreEqual(1000, objAccount.Balance);
            Assert.AreEqual(AccountState.Safe, objAccount.State);
        }

        [TestMethod]//, ExpectedException(typeof(ArgumentException))]
        public void TestMethodDepositNegative()
        {
            objAccount.Deposit(-200);
            Assert.AreEqual(1000, objAccount.Balance);

        }

        [TestMethod]
        public void TestMethodDepositWithdrawPositiveNegative()
        {
            objAccount.Deposit(200);
            objAccount.Withdraw(800);
            objAccount.Withdraw(-400);
            Assert.AreEqual(400, objAccount.Balance);
            Assert.AreEqual(AccountState.Safe, objAccount.State);
        }

        [TestMethod]
        public void TestMethodWithdrawBalanceOverdraft()
        {
            objAccount.Withdraw(1200);
            Assert.AreEqual(-200, objAccount.Balance);
            Assert.AreEqual(AccountState.InOD, objAccount.State);
        }
    }
}