using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockPriceChecker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockPriceChecker.Controllers
{
    public class StockPriceController : Controller
    {
        // Add your other methods and properties here

        public async Task<ActionResult> GetStockPrice(string tickerSymbol)
        {
            // Make an API call to retrieve the stock price data using the RealStonks API
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://realstonks.p.rapidapi.com/TSLA"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c0cef5ee96msh2108c722f3fe6dap18231cjsn05d6ed2c81b7" },
                    { "X-RapidAPI-Host", "realstonks.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }


            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://realstonks.p.rapidapi.com/TSLA" + tickerSymbol);

                if (response.IsSuccessStatusCode)
                {
                    // Parse the JSON response into a StockPrice object
                    var json = await response.Content.ReadAsStringAsync();
                    var stockPrice = JsonConvert.DeserializeObject<StockPrice>(json);

                    ViewBag.Title = ("Stock Price for " + stockPrice.TickerSymbol);


                    // Return the StockPrice object to the view
                    return View(stockPrice);
                }
                else
                {
                    // Handle errors appropriately
                    return View("Error");
                }
            }
        }
    }

}

