using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockPriceChecker.Models;

namespace StockPriceChecker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetStockPrice(FormCollection form)
    {
        string tickerSymbol = form["tickerSymbol"];

        //code to call api and deserialize

        string apiUrl = $"https://realstonks.p.rapidapi.com/price/{tickerSymbol}";

        //code to call api and deserialize

        return View("StockPrice", stockPrice);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

