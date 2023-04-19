using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://realstonks.p.rapidapi.com/TSLA" + tickerSymbol);

                if (response.IsSuccessStatusCode)
                {
                    // Parse the JSON response into a StockPrice object
                    var json = await response.Content.ReadAsStringAsync();
                    var stockPrice = JsonConvert.DeserializeObject<StockPrice>(json);

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

