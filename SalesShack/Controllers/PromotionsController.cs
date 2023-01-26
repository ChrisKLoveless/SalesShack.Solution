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
    public class PromotionsController : Controller
    {
        private readonly SalesShackContext _db;
        public PromotionsController(SalesShackContext db)
        {
            _db = db;
        }


        [Authorize(Roles = "Administrator, User")]
        public ActionResult Index()
        {
            List<Promotion> promotions = _db.Promotions.Include(promotion => promotion.Product).ToList();
            return View(promotions);
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Promotion promotion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
                return View(promotion);
            }
            else
            {
                _db.Promotions.Add(promotion);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [Authorize(Roles = "Administrator, User")]
        public ActionResult Details(int id)
        {
            Promotion thisPromotion = _db.Promotions
            // .Include(promotion => promotion.JoinEntities)
            .Include(p => p.Product)
            .FirstOrDefault(promotion => promotion.PromotionId == id);
            return View(thisPromotion);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Promotion thisPromotion = _db.Promotions.FirstOrDefault(promotion => promotion.PromotionId == id);
            return View(thisPromotion);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Promotion promotion)
        {
            _db.Promotions.Update(promotion);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Promotion thisPromotion = _db.Promotions.FirstOrDefault(promotion => promotion.PromotionId == id);
            return View(thisPromotion);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Promotion thisPromotion = _db.Promotions.FirstOrDefault(promotion => promotion.PromotionId == id);
            _db.Promotions.Remove(thisPromotion);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}