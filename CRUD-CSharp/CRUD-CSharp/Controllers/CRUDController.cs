using CRUD_CSharp.Contexts;
using CRUD_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CRUD_CSharp.Controllers
{
    public class CRUDController : Controller
    {
        readonly CRUDContext _db = new CRUDContext();

        public ActionResult Main()
        {
            List<Product> products = new List<Product>();

            foreach (var product in _db.Products)
            {
                products.Add(product);
            }

            return View(products);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product _product)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = _product.Name,
                    Description = _product.Description,
                    Price = _product.Price
                };

                _db.Products.Add(product);
                _db.SaveChanges();

                return RedirectToAction("Main");
            }

            return new HttpStatusCodeResult(400);
        }

        public ActionResult ShowProduct(int? Id)
        {
            if (Id != null)
            {
                Product activeProduct = _db.Products.FirstOrDefault(p => p.ID == Id);

                if (activeProduct != null)
                {
                    return View(activeProduct);
                }
            }

            return new HttpStatusCodeResult(404);


        }

        public ActionResult Delete(int? ID)
        {
            if (ID != null)
            {
                Product activeProduct = _db.Products.FirstOrDefault(p => p.ID == ID);

                if (activeProduct != null)
                {
                    _db.Products.Remove(activeProduct);
                    _db.SaveChanges();

                    return RedirectToAction("Main");
                }
            }

            return new HttpStatusCodeResult(404);

        }

        public ActionResult Edit(int? ID)
        {
            if (ID != null)
            {
                Product activeProduct = _db.Products.FirstOrDefault(p => p.ID == ID);

                if (activeProduct != null)
                {
                    return View(activeProduct);
                }
            }

            return new HttpStatusCodeResult(404);

        }

        [HttpPost]
         public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Main");
            }

            return new HttpStatusCodeResult(400);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
