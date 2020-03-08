using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Classes.Accounts
{
    public class CorporateInvestment : AccountBase
    {
        #region ctors
        //All default constructors are private, no ctor without owner or properties
        public CorporateInvestment(String accountNumber, String ownerId, String lastName, String firstName, decimal balance) : base(accountNumber, ownerId, lastName, firstName, balance) { }
        public CorporateInvestment(String accountNumber, AccountOwner owner, decimal balance) : base(accountNumber, owner, balance) { }
        #endregion
    }
}
