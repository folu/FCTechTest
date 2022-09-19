using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout
    {
        //catalogue
        //basket
        public Checkout()
        {
            
        }

        public decimal Total()
        {
            //calculate total price for all items in the basket
            return 0m;
        }

        public void Scan(Item item)
        {
            // items will be scanned, valided against catalogue before adding to basket

        }
    }
}
