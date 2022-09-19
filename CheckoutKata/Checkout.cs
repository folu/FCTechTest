using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly IEnumerable<Item> catalog;
        private readonly List<Item> basket;

        public Checkout(IEnumerable<Item> catalog)
        {
            this.catalog = catalog;
        }

        public decimal Total()
        {
            decimal total = 0;
            //calculate total price for all items in the basket
            total = basket.Sum(x => Convert.ToDecimal(x.Price));
            return total;
        }

        public void Scan(string sku)
        {
            // items will be scanned, valided against catalogue before adding to basket
            if (!string.IsNullOrEmpty(sku))
            {
                var fullItem = catalog.Single(p => p.SKU == sku);
                if (fullItem != null)
                {
                    basket.Add(fullItem);
                }
            }
        }
    }
}
