using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Classes.Accounts
{
    public class Checking : AccountBase
    {
        #region ctors
        //All default constructors are private, no ctor without owner or properties
        public Checking(String accountNumber, String ownerId, String lastName, String firstName, decimal balance) : base(accountNumber, ownerId, lastName, firstName, balance) { }
        public Checking(String accountNumber, AccountOwner owner, decimal balance) : base(accountNumber, owner, balance) { }
        #endregion
    }
}
