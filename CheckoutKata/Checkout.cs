using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<Item> catalog;
        private readonly IEnumerable<Discount> discounts;
        public List<Item> basket = new List<Item>();
        
        
        public Checkout(IEnumerable<Item> catalog)
        {
            this.catalog = catalog;
        }
        public Checkout(IEnumerable<Item> catalog, IEnumerable<Discount> discounts)
        {
            this.catalog = catalog;
            this.discounts = discounts;
        }

        public void Empty()
        {
            if (basket.Any())
            {
                basket.Clear();
            }
        }

        public decimal Total()
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            //calculate total price for all items in the basket
            if (basket.Any())
            {
                total = basket.Sum(x => Convert.ToDecimal(x.Price));
                totalDiscount = discounts.Sum(discount => CalculateDiscount(discount));
            }
            return total - totalDiscount;
        }

        public void Scan(string sku)
        {
            // items will be scanned, valided against catalogue before adding to basket
            if (!string.IsNullOrEmpty(sku))
            {
                var fullItem = catalog.SingleOrDefault(p => p.SKU == sku);
                if (fullItem != null)
                {
                    basket.Add(fullItem);
                }
            }
        }
        private decimal CalculateDiscount(Discount discount)
        {
            //no need to apply this to interface as we might not always want to add discount
            int basketItemCount = basket.Count(item => item.SKU == discount.SKU);
            decimal defaultDecimal = 0.00m;
            if (basketItemCount > (int)defaultDecimal)
            {
                decimal originalSinglePrice = basket.FirstOrDefault(item => item.SKU == discount.SKU).Price;

                var offerPrice = (basketItemCount / discount.Quantity) * discount.Value;
                var discountResult = (originalSinglePrice * discount.Quantity) - offerPrice;
                var result = (offerPrice > defaultDecimal) ? discountResult : offerPrice;
                return result;
            }
            return defaultDecimal;
        }
    }
}
