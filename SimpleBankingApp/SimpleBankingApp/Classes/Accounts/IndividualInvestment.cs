using System;
using System.Collections.Generic;
using System.Text;
using SimpleBankingApp.Enums;

namespace SimpleBankingApp.Classes.Accounts
{
    public class IndividualInvestment : AccountBase
    {
        #region ctors
        //All default constructors are private, no ctor without owner or properties
        public IndividualInvestment(String accountNumber, String ownerId, String lastName, String firstName, decimal balance) : base(accountNumber, ownerId, lastName, firstName, balance) { }
        public IndividualInvestment(String accountNumber, AccountOwner owner, decimal balance) : base(accountNumber, owner, balance) { }
        #endregion

        public override ReturnCode Withdraw(decimal amount)
        {
            if (amount < 0)
                return ReturnCode.Request_Less_Than_Zero;
            if (amount > Balance || amount > 1000)
                return ReturnCode.Request_Greater_Than_Allowed;
            Balance -= amount;
            return 0;
        }
    }
}
