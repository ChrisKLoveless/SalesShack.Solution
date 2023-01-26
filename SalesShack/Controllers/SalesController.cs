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
    [Authorize(Roles = "User")]

    public class SalesController : Controller
    {
        private readonly SalesShackContext _db;
        public SalesController(SalesShackContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Sale> sales = _db.Sales.Include(sale => sale.Product).ToList();
            return View(sales);
        }

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
                return View(sale);
            }
            else
            {
                _db.Sales.Add(sale);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            Sale thisSale = _db.Sales
            .Include(s => s.Product)
            .FirstOrDefault(sale => sale.SaleId == id);
            return View(thisSale);
        }

        public ActionResult Edit(int id)
        {
            Sale thisSale = _db.Sales.FirstOrDefault(sale => sale.SaleId == id);
            return View(thisSale);
        }

        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            _db.Sales.Update(sale);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Sale thisSale = _db.Sales.FirstOrDefault(sale => sale.SaleId == id);
            return View(thisSale);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Sale thisSale = _db.Sales.FirstOrDefault(sale => sale.SaleId == id);
            _db.Sales.Remove(thisSale);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}