using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using StockPriceChecker.Models;

namespace StockPriceChecker
{
	public class StockRepo : IStockRepo
	{
		public StockRepo()
		{
		}

        public async Task<ActionResult> GetStockPrice(string tickerSymbol)
        {
            var client = new RestClient($"https://realstonks.p.rapidapi.com/{tickerSymbol}");
            var request = new RestRequest();
            request.AddHeader("content-type", "application/octet-stream");
            request.AddHeader("X-RapidAPI-Key", "c0cef5ee96msh2108c722f3fe6dap18231cjsn05d6ed2c81b7");
            request.AddHeader("X-RapidAPI-Host", "realstonks.p.rapidapi.com");
            var response = client.Execute(request);

            //using (var httpClient = new HttpClient())
            //{
            //    var response = await httpClient.GetAsync($"https://realstonks.p.rapidapi.com/price/{tickerSymbol}");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Parse the JSON response into a StockPrice object
            //        var json = await response.Content.ReadAsStringAsync();
            //        var stockPrice = JsonConvert.DeserializeObject<StockPrice>(json);

            //        ViewBag.Title = ("Stock Price for " + stockPrice.TickerSymbol);

            //        // Return the StockPrice object to the view
            //        return View(stockPrice);
            //    }
            //    else
            //    {
            //        // Handle errors appropriately
            //        return View("Error");
            //    }
            //}
        }
    }
}

