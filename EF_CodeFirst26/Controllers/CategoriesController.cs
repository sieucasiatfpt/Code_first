using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirst26.Models;

namespace EF_CodeFirst26.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            using (CompanyDB26Context db = new CompanyDB26Context())
            {
                List<Category> categories = db.Categories.ToList();

                return View(categories);
            }
        }
    }
}