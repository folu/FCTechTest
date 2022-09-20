// See https://aka.ms/new-console-template for more information
using CheckoutKata;

ICheckout till;

IEnumerable<Item> catalog = new[]
{
   new Item{SKU = "A99", Price = 0.50m},
   new Item{SKU = "B15", Price = 0.30m},
   new Item{SKU = "C40", Price = 0.60m},
};
IEnumerable<Discount> discounts = new[]
{
   new Discount{SKU = "A99", Quantity = 3, Value = 1.30m},
   new Discount{SKU = "B15", Quantity = 2, Value = 0.45m}
};

till = new Checkout(catalog, discounts);
till.Empty();

string item = "";
string scan = "SCAN";
do
{
    Console.WriteLine("Hello please enter an item!");
    item = Console.ReadLine();
    item = item.Trim().ToUpper();
    till.Scan(item);
} while (item != scan);

Console.WriteLine(till.Total());