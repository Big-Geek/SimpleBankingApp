using System;
using System.Collections.Generic;
using System.Text;


namespace SimpleBankingApp.Classes
{
    public class Bank
    {
        #region Properties
        public String Name { get; private set; }
        public String BankId { get; private set; }
        public AccountsList Accounts { get; private set; }
        #endregion

        #region ctor
        public Bank(String name, String bankId)
        {
            this.Name = name;
            this.BankId = bankId;
            AccountsObjectNullCheck();
        }
        #endregion

        #region Methods
        public void LoadAccounts(AccountsList accountsList)
        {
            AccountsObjectNullCheck();
            this.Accounts.LoadAccounts(accountsList.Accounts);
        }

        public override string ToString()
        {
            String accountListCount = Accounts == null ? "Not Initialized" : Accounts.GetCount().ToString();
            return String.Format("Bank Name: {0}|BankId: {1}|Total Number of Accounts: {2}|Type: {3}", Name, BankId, accountListCount, this.GetType().ToString());
        }

        private void AccountsObjectNullCheck()
        {
            if (this.Accounts == null)
                Accounts = new AccountsList(BankId);
        }
        #endregion


    }
}
