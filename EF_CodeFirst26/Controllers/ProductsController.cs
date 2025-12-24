using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirst26.Models;

namespace EF_CodeFirst26.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDB26Context db = new CompanyDB26Context();

        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "ProductID", string IconClass = "fa-sort-asc", int page = 1)
        {
            // Search
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;

            // Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductID).ToList();
                }
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.Price).ToList();
                }
            }

            // Paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (page - 1) * NoOfRecordsPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            return View(products);
        }

        public ActionResult Detail(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            Product product = db.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();

            // Update
            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.DateOfPurchase = pro.DateOfPurchase;
            product.AvailabilityStatus = pro.AvailabilityStatus;
            product.CategoryID = pro.CategoryID;
            product.BrandID = pro.BrandID;
            product.Active = pro.Active;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}