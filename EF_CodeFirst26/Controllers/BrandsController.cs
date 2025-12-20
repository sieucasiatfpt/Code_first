using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirst26.Models;

namespace EF_CodeFirst26.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDB26Context db = new CompanyDB26Context();
            List<Brand> brands = db.Brands.ToList();

            return View(brands);
        }
    }
}