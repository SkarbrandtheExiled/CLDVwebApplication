using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLDVwebApplication.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Products(int userID)
    {
        var products = productTable.GetAllProducts();

        ViewData["products"] = products;
        ViewData["userID"] = userID;

        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult signUp()
    {
        return View();
    }

    public IActionResult MyWork()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult contact()
    {
        return View();
    }

    public IActionResult Orders()
    {
        var orders = transactionTable.GetAllOrders();

        ViewData["Orders"] = orders;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}