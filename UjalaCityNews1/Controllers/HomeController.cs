using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UjalaCityNews1.DAL;
using UjalaCityNews1.Models;
using static UjalaCityNews1.DAL.CommonDAL;

namespace UjalaCityNews1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommonDAL _commonDal = new CommonDAL();
        public ActionResult Index()
        {
            var list =  _commonDal.Proc_GetNewsByCategory();
            var postCatWiseList = list
            .GroupBy(post => post.Category)
            .Select(group => new PostCatWise
            {
                CategoryItem = group.Key,
                Posts = group.ToList()
            })
            .ToList();
            var sliderList = _commonDal.GetSliderListForHome();

            return View(new HomeIndexContent
            {
                PostCatWise = postCatWiseList,
                HomeSlider = sliderList
            });
        }
        public ActionResult Category(string title)
        {
            var list =  _commonDal.Proc_GetNewsByCategory(title);
            var postCatWiseList = list
            .GroupBy(post => post.Category)
            .Select(group => new PostCatWise
            {
                CategoryItem = group.Key,
                Posts = group.ToList()
            })
            .ToList();
            return View(postCatWiseList);
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

        public ActionResult Politics(string title)
        {
            var news = _commonDal.GetNewsPostByTitle("Politics"); // Assuming you have a method to get posts by category
            return View(news);
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

        public ActionResult News(string title) 
        {
            var news = _commonDal.GetNewsPostByTitle(title);
            return View(news ?? new NewsPosts());
        }
        public ActionResult Videos()
        {
            return View();
        }
        public ActionResult Login()
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
            _commonDal.AddContact(model);
            return Json("Contact Data Saved Succefully");
        }
    }
}