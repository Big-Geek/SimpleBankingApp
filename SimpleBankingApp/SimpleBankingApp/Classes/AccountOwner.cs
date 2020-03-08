
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingApp.Classes
{
    public class AccountOwner
    {
        #region Properties
        public String OwnerId { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        #endregion

        #region ctor
        public AccountOwner(String ownerId, String lastName, String firstName)
        {
            this.OwnerId = ownerId;
            this.LastName = lastName;
            this.FirstName = firstName;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id: " + OwnerId + "|Name: " + LastName + ", " + FirstName;
        }
        #endregion 
    }
}
