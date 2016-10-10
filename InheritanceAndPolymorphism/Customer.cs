using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//We do the example of the Customer and wallet example to show a 'Has A' relaltionship
//The wallet is not a Customer, a customer is not a Wallet
namespace InheritanceAndPolymorphism
{
    public class Customer
    {
        protected Wallet Wallet { get; set; }
        public decimal GetMoney(decimal amount)
        {
            var whatIHave = Wallet.GetMoney(amount);
            if (whatIHave == amount)
                return amount;
            //Whoops. Not enough cash.
            //Use credit card?
            return -1;
        }
    }
}
