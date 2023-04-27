using System;
using Microsoft.AspNetCore.Mvc;

namespace StockPriceChecker
{
	public interface IStockRepo
	{
        public Task<ActionResult> GetStockPrice(string tickerSymbol);

    }
}

