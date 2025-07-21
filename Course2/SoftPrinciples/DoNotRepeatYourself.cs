namespace SoftPrinciples
{
    public static class PriceFormatter
    {
        public static string FormatPrice(this decimal price, string currencySymbol)
        {
            return string.Format("{0}{1}", currencySymbol, price);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public string GetFormattedBalance()
        {
            //var formattedPrice = string.Format("{0}{1}", "$", Balance); $100
            return Balance.FormatPrice("$");
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string GetFormattedPrice()
        {
            //var formattedPrice = string.Format("{0}{1}", "€", Price);
            return Price.FormatPrice("€");
        }
    }
}
