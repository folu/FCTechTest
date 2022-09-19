using CheckoutKata;
using Microsoft.Win32;

namespace CheckoutNunitTest
{
    public class CheckoutTest
    {
        private ICheckout till;

        [SetUp]
        public void Setup()
        {
            IEnumerable<Item> catalog = new[]
           {
                new Item{SKU = "A99", Price = 0.50},
                new Item{SKU = "B15", Price = 0.30},
                new Item{SKU = "C40", Price = 0.60},
            };

            till = new Checkout(catalog);
        }

        [Test]
        public void No_items_returns_zero()
        {
            till.Empty();
            till.Scan("");
            var total = till.Total();
            Assert.That(total, Is.EqualTo(0.00));
        }

        [TestCase("A9", 0.00)]
        [TestCase("9", 0.00)]
        [TestCase("99", 0.00)]
        [TestCase("Test", 0.00)]
        public void Invalid_items_returns_zero(string sku, decimal expected)
        {
            till.Empty();
            till.Scan("");
            var total = till.Total();
            Assert.That(total, Is.EqualTo(0.00));
        }

        [TestCase("A99", 0.50)]
        [TestCase("B15", 0.30)]
        [TestCase("C40", 0.60)]
        public void Process_Single_Scan(string sku, decimal expected)
        {
            till.Empty();
            till.Scan(sku);
            var total = till.Total();
            Assert.That(total, Is.EqualTo(expected));
        }

        [TestCase(new string[] {"A99","B15","C40"}, 1.40)]
        [TestCase(new string[] { "A99", "B15", "A99" }, 1.30)]
        public void Process_Multiple_Scans(string[] skus, decimal expected)
        {
            till.Empty();
            foreach (string sku in skus)
            {
                till.Scan(sku);
            }

            var total = till.Total();
            Assert.That(total, Is.EqualTo(expected));
        }

    }
}