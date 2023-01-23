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

    public ActionResult Details(int id)
    {
      Product thisProduct = _db.Products
      .Include(product => product.JoinEntities)
      .ThenInclude(join => join.Sale)
      .FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    public ActionResult Edit(int id)
    {
      Product thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
      _db.Products.Update(product);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Product thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Product thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      _db.Products.Remove(thisProduct);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
