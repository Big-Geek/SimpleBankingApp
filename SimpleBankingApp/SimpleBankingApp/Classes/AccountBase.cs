using System;
using System.Collections.Generic;
using System.Text;
using SimpleBankingApp.Interfaces;
using SimpleBankingApp.Enums;

namespace SimpleBankingApp.Classes
{
    public class AccountBase : IAccount
    {
        //Identity
        public String AccountNumber { get; set; }
        public AccountOwner Owner { get; private set; }
        //Funds
        public decimal Balance { get; set; }

        #region ctors
        private AccountBase() { }

        public AccountBase(String accountNumber, String ownerId, String lastName, String firstName, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Owner = new Classes.AccountOwner(ownerId, lastName, firstName);
            this.Balance = balance;
        }

        public AccountBase(String accountNumber, AccountOwner owner, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Owner = owner;
            this.Balance = balance;
        }
        #endregion 

        //Transaction Methods
        public virtual ReturnCode Deposit(decimal amount)
        {
            if (amount < 0)
                return ReturnCode.Request_Less_Than_Zero;
            Balance += amount;
            return 0;
        }
        public virtual ReturnCode Withdraw(decimal amount)
        {
            if (amount < 0)
                return ReturnCode.Request_Less_Than_Zero;
            if (amount > Balance)
                return ReturnCode.Request_Greater_Than_Allowed;
            Balance -= amount;
            return 0;
        }

        public override string ToString()
        {
            return "AccountNumber: " + AccountNumber + "|AccountType: " + this.GetType().ToString() + "|Balance: " + String.Format("{0:C2}", Balance) + "|" + Owner.ToString();
        }
    }
}
