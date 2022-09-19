using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public interface ICheckout
    {
        public void Scan(Item item);
        public decimal Total();
    }
}
