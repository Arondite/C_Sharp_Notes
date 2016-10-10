using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
   public class Wallet
    {
        public decimal TotalMoney { get; protected set; }
        public decimal GetMoney(decimal amount)
        {
            if(TotalMoney > amount)
            {
                TotalMoney -= amount;
                return amount;
            }
            TotalMoney = 0;
            return TotalMoney;
        }

    }
}
