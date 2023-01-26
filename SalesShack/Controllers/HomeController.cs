using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SalesShack.Models;

namespace SalesShack.Solution.Controllers;

public class HomeController : Controller
{
    private readonly SalesShackContext _db;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, SalesShackContext db)
    {
        _logger = logger;
        _db = db;
    }
    public IActionResult Index()
    {
        Product[] products = _db.Products.ToArray();
        Promotion[] promotions = _db.Promotions.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>();
        model.Add("Products", products);
        model.Add("Promotions", promotions);
        return View(model);
    }
}
