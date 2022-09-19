// See https://aka.ms/new-console-template for more information
using CheckoutKata;

ICheckout till;

IEnumerable<Item> catalog = new[]
{
   new Item{SKU = "A99", Price = 0.50},
   new Item{SKU = "B15", Price = 0.30},
   new Item{SKU = "C40", Price = 0.60},
};

till = new Checkout(catalog);
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