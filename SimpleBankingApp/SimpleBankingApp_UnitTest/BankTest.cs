using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Diagnostics; //Replaced for output by TestingFileOut Class
using SimpleBankingApp.Classes;
using SimpleBankingApp.Enums;
using SimpleBankingApp.Interfaces;
using acct = SimpleBankingApp.Classes.Accounts;
using System.IO;
using System.Reflection;

namespace SimpleBankingApp_UnitTest
{
    [TestClass]
    public class BankTest
    {
        TestingFileOut Debug = new TestingFileOut();

        [TestMethod]
        public void SimpleBankingAppTest_BuildBankWithoutAccounts_BankHasNameAndNoAccounts()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();

            //Act

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.ToString());
            Debug.WriteLine(testBank.Accounts.GetCount().ToString());
            

            //Assert
            // When list is null within AccountsList object, value returned from GetCount() == -1
            // Bank Name cannot be null
            Assert.IsTrue(testBank.Accounts.GetCount() == -1 && !String.IsNullOrEmpty(testBank.Name));
        }

        [TestMethod]
        public void SimpleBankingAppTest_BuildBankWithAccounts_BankHasAccounts()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Act

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.ToString());
            Debug.WriteLine(testBank.Accounts.GetCount().ToString());
            

            //Assert
            Assert.IsTrue(testBank.Accounts.GetCount() == 33);
        }

        [TestMethod]
        public void SimpleBankingAppTest_BuildBankWithAccounts_AccountCreatedWithoutOwner()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output 
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());

            //Act
            //All default constructors are inaccessible
            AccountOwner owner1 = new AccountOwner(Guid.NewGuid().ToString(), "Washington", "George");
            //acct.Checking acctcx1 = new acct.Checking();
            acct.Checking acctcx2 = new acct.Checking("0000000001cx", Guid.NewGuid().ToString(), "Washington", "George", 1.00m);
            acct.Checking acctcx3 = new acct.Checking(Guid.NewGuid().ToString(), owner1, 1.00m);

            //All default constructors are inaccessible
            //acct.CorporateInvestment acctci1 = new acct.CorporateInvestment();
            acct.CorporateInvestment acctci2 = new acct.CorporateInvestment(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Washington", "George", 1.00m);
            acct.CorporateInvestment acctci3 = new acct.CorporateInvestment(Guid.NewGuid().ToString(), owner1, 1.00m);

            //All default constructors are inaccessible
            //acct.IndividualInvestment acctii1 = new acct.IndividualInvestment();
            acct.IndividualInvestment acctii2 = new acct.IndividualInvestment(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Washington", "George", 1.00m);
            acct.IndividualInvestment acctii3 = new acct.IndividualInvestment(Guid.NewGuid().ToString(), owner1, 1.00m);

            //Output
            Debug.WriteLine(owner1.ToString());
            Debug.WriteLine(acctcx2.ToString());
            Debug.WriteLine(acctcx3.ToString());
            Debug.WriteLine(acctci2.ToString());
            Debug.WriteLine(acctci3.ToString());
            Debug.WriteLine(acctii2.ToString());
            Debug.WriteLine(acctii3.ToString());

            //Assert
            //All accounts are succesfully built, resulting in a true assertion
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SimpleBankingAppTest_BuildBankWithAccounts_AllAccountsHaveOwner()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output 
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.ToString());
            Debug.WriteLine(testBank.Accounts.GetCount().ToString());


            //Act
            bool allAccountsHaveOwners = true;
            foreach (IAccount acct in testBank.Accounts.GetAllAccountsList())
            {
                if (acct.Owner == null)
                {
                    allAccountsHaveOwners = false;
                    continue;
                }
                //Output
                Debug.WriteLine(acct.AccountNumber.ToString());
                Debug.WriteLine(acct.Owner.ToString());
            }

            //Assert
            Assert.IsTrue(allAccountsHaveOwners);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_CheckingAccountDirectDeposit()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Act
            testBank.Accounts.Deposit(1000.00m, "0000000001cx");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance == 1001.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_CorporateInvestmentAccountDirectDeposit()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());

            //Act
            testBank.Accounts.Deposit(1000.00m, "0000000001ci");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance == 1001.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_IndividualInvestmentAccountDirectDeposit()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());

            //Act
            testBank.Accounts.Deposit(1000.00m, "0000000001ii");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            
            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance == 1001.00m);
        }


        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_CheckingAccountDirectWithdrawal()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011cx").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000011cx");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011cx").ToString());
            

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000011cx").Balance == 99000.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_CorporateInvestmentAccountDirectWithdrawal()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ci").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000011ci");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ci").ToString());

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000011ci").Balance == 99000.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_IndividualInvestmentAccountDirectWithdrawal()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000011ii");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").ToString());
            

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").Balance == 99000.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestDeposit_CheckingAccountDirectWithdrawalOverdraft()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000001cx");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance == 1.00m);
        }

        /// <summary>
        /// Withdraw Methods
        /// </summary>

        [TestMethod]
        public void SimpleBankingAppTest_TestWithdraw_CorporateInvestmentAccountDirectWithdrawalOverdraft()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000001ci");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            
            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance == 1.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestWithdraw_IndividualInvestmentAccountDirectWithdrawalOverdraft()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.00m, "0000000001ii");

            //Output            
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance == 1.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestWithdraw_IndividualInvestmentAccountDirectWithdrawalOverAllowedMax()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").ToString());

            //Act
            testBank.Accounts.Withdraw(1000.01m, "0000000011ii");

            //Output
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").ToString());
            

            //Assert
            Assert.IsTrue(testBank.Accounts.GetAccountByAccountNumber("0000000011ii").Balance == 100000.00m);
        }

        /// <summary>
        /// Transfer Methods
        /// </summary>
        /// 
        ///Checking Transfers
        //////

        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_CheckingAccountTransferToCorporateInvSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal cxBal, ciBal;
            

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001cx", "0000000001ci");
            cxBal = testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance;
            ciBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            

            //Assert
            Assert.IsTrue(cxBal == 0m && ciBal == 2.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_CheckingAccountTransferToIndividualInvSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal cxBal, iiBal;


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001cx", "0000000001ii");
            cxBal = testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance;
            iiBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            

            //Assert
            Assert.IsTrue(cxBal == 0m && iiBal == 2.00m);
        }

        /// 
        /// CorporateInvestment Transfers
        /// 


        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_CorporateInvestmentAccountTransferToCheckingSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal ciBal, cxBal;


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001ci", "0000000001cx");
            ciBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance;
            cxBal = testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            

            //Assert
            Assert.IsTrue(ciBal == 0m && cxBal == 2.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_CorporateInvestmentAccountTransferToIndividualInvSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal ciBal, iiBal;


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001ci", "0000000001ii");
            ciBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance;
            iiBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            

            //Assert
            Assert.IsTrue(ciBal == 0m && iiBal == 2.00m);
        }

        /// 
        /// Individual Investment
        /// 


        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_IndividualInvestmentAccountTransferToCheckingSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal iiBal, cxBal;


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001ii", "0000000001cx");
            iiBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance;
            cxBal = testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            

            //Assert
            Assert.IsTrue(iiBal == 0m && cxBal == 2.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_IndividualInvestmentAccountTransferToCorporateInvSameOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal iiBal, ciBal;


            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001ii", "0000000001ci");
            iiBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ii").Balance;
            ciBal = testBank.Accounts.GetAccountByAccountNumber("0000000001ci").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ii").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001ci").ToString());
            

            //Assert
            Assert.IsTrue(iiBal == 0m && ciBal == 2.00m);
        }

        [TestMethod]
        public void SimpleBankingAppTest_TestTransfer_CheckingAccountTransferToCheckingDifferentOwnerSuccessful()
        {
            //Arrange
            //Build Bank
            Bank testBank = BuildBank();
            BuildBankAccountList(ref testBank);

            decimal cxBal, ciBal;

            //Output
            Debug.SetMethodName(MethodBase.GetCurrentMethod().Name.ToString());
            Debug.WriteLine("Before Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000002cx").ToString());

            //Act
            testBank.Accounts.Transfer(1.00m, "0000000001cx", "0000000002cx");
            cxBal = testBank.Accounts.GetAccountByAccountNumber("0000000001cx").Balance;
            ciBal = testBank.Accounts.GetAccountByAccountNumber("0000000002cx").Balance;

            //Output
            Debug.WriteLine("After Transaction");
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000001cx").ToString());
            Debug.WriteLine(testBank.Accounts.GetAccountByAccountNumber("0000000002cx").ToString());
            
            //Assert
            Assert.IsTrue(cxBal == 0m && ciBal == 3.00m);
        }

        public Bank BuildBank()
        {
            //Create Bank
            String bankId = Guid.NewGuid().ToString();
            String bankName = "Tightwad Bank of Tightwad, MO";
            Bank myBank = new Bank(bankName, bankId);

            return myBank;
        }

        public void BuildBankAccountList(ref Bank myBank)
        {
            AccountsList accountsList = BuildAccountsList(myBank.BankId);
            myBank.LoadAccounts(accountsList);
        }

        public AccountsList BuildAccountsList(String bankId)
        {
            AccountsList accountsList = new AccountsList(bankId);
            AccountOwner owner1 = new AccountOwner(Guid.NewGuid().ToString(), "Washington", "George");
            AccountOwner owner2 = new AccountOwner(Guid.NewGuid().ToString(), "Jefferson", "Thomas");
            AccountOwner owner3 = new AccountOwner(Guid.NewGuid().ToString(), "Lincoln", "Abraham");
            AccountOwner owner4 = new AccountOwner(Guid.NewGuid().ToString(), "Hamilton", "Alexander");
            AccountOwner owner5 = new AccountOwner(Guid.NewGuid().ToString(), "Jackson", "Andrew");
            AccountOwner owner6 = new AccountOwner(Guid.NewGuid().ToString(), "Grant", "Ulysses");
            AccountOwner owner7 = new AccountOwner(Guid.NewGuid().ToString(), "Franklin", "Benjamin");
            AccountOwner owner8 = new AccountOwner(Guid.NewGuid().ToString(), "McKinley", "William");
            AccountOwner owner9 = new AccountOwner(Guid.NewGuid().ToString(), "Cleveland", "Grover");
            AccountOwner owner10 = new AccountOwner(Guid.NewGuid().ToString(), "Chase", "Salmon");
            AccountOwner owner11 = new AccountOwner(Guid.NewGuid().ToString(), "Wilson", "Woodrow");

            //String accountNumber, String ownerId, String lastName, String firstName, decimal balance
            //String accountNumber, AccountOwner owner, decimal balance
            IAccount account1 = new acct.Checking("0000000001cx", owner1, 1.00m);
            IAccount account2 = new acct.Checking("0000000002cx", owner2, 2.00m);
            IAccount account3 = new acct.Checking("0000000003cx", owner3, 5.00m);
            IAccount account4 = new acct.Checking("0000000004cx", owner4, 10.00m);
            IAccount account5 = new acct.Checking("0000000005cx", owner5, 20.00m);
            IAccount account6 = new acct.Checking("0000000006cx", owner6, 50.00m);
            IAccount account7 = new acct.Checking("0000000007cx", owner7, 100.00m);
            IAccount account8 = new acct.Checking("0000000008cx", owner8, 500.00m);
            IAccount account9 = new acct.Checking("0000000009cx", owner9, 1000.00m);
            IAccount account10 = new acct.Checking("0000000010cx", owner10, 10000.00m);
            IAccount account11 = new acct.Checking("0000000011cx", owner11, 100000.00m);

            IAccount account1ci = new acct.CorporateInvestment("0000000001ci", owner1, 1.00m);
            IAccount account2ci = new acct.CorporateInvestment("0000000002ci", owner2, 2.00m);
            IAccount account3ci = new acct.CorporateInvestment("0000000003ci", owner3, 5.00m);
            IAccount account4ci = new acct.CorporateInvestment("0000000004ci", owner4, 10.00m);
            IAccount account5ci = new acct.CorporateInvestment("0000000005ci", owner5, 20.00m);
            IAccount account6ci = new acct.CorporateInvestment("0000000006ci", owner6, 50.00m);
            IAccount account7ci = new acct.CorporateInvestment("0000000007ci", owner7, 100.00m);
            IAccount account8ci = new acct.CorporateInvestment("0000000008ci", owner8, 500.00m);
            IAccount account9ci = new acct.CorporateInvestment("0000000009ci", owner9, 1000.00m);
            IAccount account10ci = new acct.CorporateInvestment("0000000010ci", owner10, 10000.00m);
            IAccount account11ci = new acct.CorporateInvestment("0000000011ci", owner11, 100000.00m);

            IAccount account1ii = new acct.IndividualInvestment("0000000001ii", owner1, 1.00m);
            IAccount account2ii = new acct.IndividualInvestment("0000000002ii", owner2, 2.00m);
            IAccount account3ii = new acct.IndividualInvestment("0000000003ii", owner3, 5.00m);
            IAccount account4ii = new acct.IndividualInvestment("0000000004ii", owner4, 10.00m);
            IAccount account5ii = new acct.IndividualInvestment("0000000005ii", owner5, 20.00m);
            IAccount account6ii = new acct.IndividualInvestment("0000000006ii", owner6, 50.00m);
            IAccount account7ii = new acct.IndividualInvestment("0000000007ii", owner7, 100.00m);
            IAccount account8ii = new acct.IndividualInvestment("0000000008ii", owner8, 500.00m);
            IAccount account9ii = new acct.IndividualInvestment("0000000009ii", owner9, 1000.00m);
            IAccount account10ii = new acct.IndividualInvestment("0000000010ii", owner10, 10000.00m);
            IAccount account11ii = new acct.IndividualInvestment("0000000011ii", owner11, 100000.00m);

            accountsList.Add(account1);
            accountsList.Add(account2);
            accountsList.Add(account3);
            accountsList.Add(account4);
            accountsList.Add(account5);
            accountsList.Add(account6);
            accountsList.Add(account7);
            accountsList.Add(account8);
            accountsList.Add(account9);
            accountsList.Add(account10);
            accountsList.Add(account11);
            accountsList.Add(account1ci);
            accountsList.Add(account2ci);
            accountsList.Add(account3ci);
            accountsList.Add(account4ci);
            accountsList.Add(account5ci);
            accountsList.Add(account6ci);
            accountsList.Add(account7ci);
            accountsList.Add(account8ci);
            accountsList.Add(account9ci);
            accountsList.Add(account10ci);
            accountsList.Add(account11ci);
            accountsList.Add(account1ii);
            accountsList.Add(account2ii);
            accountsList.Add(account3ii);
            accountsList.Add(account4ii);
            accountsList.Add(account5ii);
            accountsList.Add(account6ii);
            accountsList.Add(account7ii);
            accountsList.Add(account8ii);
            accountsList.Add(account9ii);
            accountsList.Add(account10ii);
            accountsList.Add(account11ii);

            return accountsList;
        }
    }
}
