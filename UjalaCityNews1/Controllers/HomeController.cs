using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UjalaCityNews1.DAL;
using UjalaCityNews1.Models;

namespace UjalaCityNews1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommonDAL _commonDal = new CommonDAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult CityState()
        {
            return View();
        }

        public ActionResult Politics()
        {
            return View();
        }
        public ActionResult Sirituality()
        {
            return View();
        }
        public ActionResult Sports()
        {
            return View();
        }
        public ActionResult LifeStyle()
        {
            return View();
        }
        public ActionResult Entertainment()
        {
            return View();
        }
        public ActionResult Crime()
        {
            return View();
        }
        public ActionResult Technology()
        {
            return View();
        }
        public ActionResult CountryAbroad()
        {
            return View();
        }
        public ActionResult Job()
        {
            return View();
        }
        public ActionResult EPaper()
        {
            return View();
        }
        public ActionResult ApniKalamSe()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Videos()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult SaveContact(ContactUs model)
        {
            _commonDal.AddPerson(model);
            return Json("Contact Data Saved Succefully");
        }
    }
}