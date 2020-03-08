using System;
using System.Collections.Generic;
using System.Text;
using SimpleBankingApp.Enums;
using SimpleBankingApp.Classes;

namespace SimpleBankingApp.Interfaces
{
    public interface IAccount
    {
        //Identity
        String AccountNumber { get; set; }
        AccountOwner Owner { get; }

        //Funds
        decimal Balance { get; set; }

        //Transaction Methods
        ReturnCode Deposit(decimal amount);
        ReturnCode Withdraw(decimal amount);
    }
}
