using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankConsole
{
    public abstract class APerson
    {
        public abstract string GetName();

        public string GetCountry()
        {
            return "Mexico";
        }

    }
}