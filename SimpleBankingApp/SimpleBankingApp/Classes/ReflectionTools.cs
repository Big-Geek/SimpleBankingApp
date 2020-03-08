using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SimpleBankingApp.Classes
{
    public static class ReflectionTools
    {
        public static String BuildMethodName(MethodBase method)
        {
            //return className + methodName
            return method.ReflectedType.Name.ToString() + "." + method.Name.ToString();
        }
    }
}
