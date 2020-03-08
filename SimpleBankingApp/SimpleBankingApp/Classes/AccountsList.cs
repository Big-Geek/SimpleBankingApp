using System;
using System.Collections.Generic;
using System.Text;
using SimpleBankingApp.Interfaces;
using SimpleBankingApp.Enums;
using System.Linq;

namespace SimpleBankingApp.Classes
{
    public class AccountsList
    {
        public String BankId { get; private set; }
        public List<IAccount> Accounts { get; private set; }

        #region ctor
        public AccountsList(String bankId)
        {
            this.BankId = bankId;
        }
        #endregion
        #region ctor methods
        public void LoadAccounts(List<IAccount> accounts)
        {
            AccountsObjectNullCheck();
            this.Accounts = accounts;
        }

        public List<IAccount> GetAllAccountsList()
        {
            return Accounts;
        }
        #endregion
        #region Methods
        public ReturnCode Deposit(decimal amount, String toAccountNumber)
        {
            IAccount toAccount = GetAccountByAccountNumber(toAccountNumber);
            return toAccount.Deposit(amount);
        }

        public ReturnCode Withdraw(decimal amount, String toAccountNumber)
        {
            IAccount toAccount = GetAccountByAccountNumber(toAccountNumber);
            return toAccount.Withdraw(amount);
        }

        public ReturnCode Transfer(decimal amount, String fromAccountNumber, String toAccountNumber)
        {
            IAccount fromAccount = GetAccountByAccountNumber(fromAccountNumber);
            IAccount toAccount = GetAccountByAccountNumber(toAccountNumber);
            ReturnCode tryWithdrawal = fromAccount.Withdraw(amount);
            if (tryWithdrawal != 0)
                return tryWithdrawal;
            ReturnCode depositCode = toAccount.Deposit(amount);
            return depositCode;
        }

        public IAccount GetAccountByAccountNumber(String accountNumber)
        {
            if (this.Accounts == null)
            {
                throw new NullReferenceException();
            }
            return this.Accounts.Where(acct => acct.AccountNumber == accountNumber).FirstOrDefault();
        }

        public void Add(IAccount account)
        {
            AccountsObjectNullCheck();
            Accounts.Add(account);
        }

        public int GetCount()
        {
            if (this.Accounts == null)
                return -1;
            return Accounts.Count();
        }

        private void AccountsObjectNullCheck()
        {
            if (this.Accounts == null)
                Accounts = new List<IAccount>();
        }

        #endregion

    }
}
