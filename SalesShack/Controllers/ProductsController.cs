using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SalesShack.Models;

namespace SalesShack.Controllers
{
  public class ProductsController : Controller
  {
    private readonly SalesShackContext _db;
    public ProductsController(SalesShackContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Product> products = _db.Products.ToList();
      return View(products);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Product product)
    {
      if (!ModelState.IsValid)
      {
        return View(product);
      }
      else
      {
        _db.Products.Add(product);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}
}