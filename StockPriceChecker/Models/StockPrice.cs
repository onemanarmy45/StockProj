using System;
namespace StockPriceChecker.Models
{
	public class StockPrice
	{
        public string TickerSymbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime Timestamp { get; set; }

        public StockPrice()
		{
		}
	}
}