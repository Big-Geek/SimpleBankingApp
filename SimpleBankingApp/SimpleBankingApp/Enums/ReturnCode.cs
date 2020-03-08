using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Enums
{
    public enum ReturnCode
    {
        Request_Less_Than_Zero=-2,
        Request_Greater_Than_Allowed=-1,
        Request_Successful=0
    }
}
