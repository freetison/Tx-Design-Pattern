namespace Observer.Model
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public Stock()
        {

        }
        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }
}