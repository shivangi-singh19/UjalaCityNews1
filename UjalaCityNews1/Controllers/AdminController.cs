﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using UjalaCityNews1.Common;
using UjalaCityNews1.DAL;
using UjalaCityNews1.Models;

namespace UjalaCityNews1.Controllers
{
    [AuthorizeUser]
    public class AdminController : Controller
    {
        private readonly CommonDAL _commonDal = new CommonDAL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactShow()
        {
            var list = _commonDal.GetContactList();
            return View(list);
        }
        public ActionResult GetPostList()
        {
            var list = _commonDal.GetNewsPostsByName();
            return PartialView("_PostList", list);
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var list = _commonDal.DeletePostById(id);
            return Json(1);
        }
        public ActionResult AddNews(int id = 0)
        {
            var news = new NewsPosts();
            if(id > 0)
            {
                news = _commonDal.GetNewsPostById(id);
                if(news == null)
                {
                    news = new NewsPosts();
                }
            }
            return View(news);
        }
        [HttpPost]
        public ActionResult AddNews(NewsPosts news)
        {
            // Check if a file is uploaded
            if (news.Image != null && news.Image.ContentLength > 0)
            {
                // Call the WebHelper method to save the file and get the path
                string filePath = WebHelper.SaveFile(news.Image, "/Content/ClientImages/PostImages/");
                news.ImagePath = filePath;
            }

            // Save or update the news post with the image path
            news.Slug = WebHelper.ConvertSpacesToHyphens(news.EnglishTitle);
            _commonDal.SaveOrUpdateNewsPost(news);

            return Json("Post Saved Succefully");
        }

        #region Categories
        public ActionResult CategoriesList()
        {
            var list = _commonDal.GetCategoriesList();
            return View(list);
        }
        public ActionResult AddCategories(int id = 0)
        {
            var model = new Categories();
            if (id > 0)
            {
                model = _commonDal.GetCategoriesById(id);
                if (model == null)
                {
                    model = new Categories();
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCategories(Categories model)
        {
            _commonDal.SaveOrUpdateCategories(model);
            return Json("Category Saved Succefully");
        }
        [HttpPost]
        public ActionResult UpdateIsActiveCategories(int id, string type = "isactive")
        {
            _commonDal.UpdateIsActiveCategories(id, type);
            return Json("Updated Succefully");
        }
        [HttpGet]
        public JsonResult GetActiveCategoriesDDL()
        {
            var catDDL = _commonDal.GetActiveCategoriesDDL();
            return Json(catDDL, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region SLider
        public ActionResult AddHomeSlider(int id = 0)
        {
            var model = new HomeSlider();
            if (id > 0)
            {
                model = _commonDal.GetHomeSliderById(id);
                if (model == null)
                {
                    model = new HomeSlider();
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddHomeSlider(HomeSlider model)
        {
            if (model.Image != null && model.Image.ContentLength > 0)
            {
                string filePath = WebHelper.SaveFile(model.Image, "/Content/ClientImages/SliderImages/");
                model.ImagePath = filePath;
            }

            model.TitleSlug = WebHelper.ConvertSpacesToHyphens(model.Title);
            _commonDal.SaveOrUpdateHomeSlider(model);

            return Json("Slider Saved Succefully");
        }
        public ActionResult SliderList()
        {
            var list = _commonDal.GetSliderList();
            return View(list);
        }
        [HttpPost]
        public ActionResult DeleteSlider(int id)
        {
            var list = _commonDal.DeleteSliderById(id);
            return Json(1);
        }
        [HttpPost]
        public ActionResult UpdateIsShowOnHome(int id)
        {
            _commonDal.UpdateIsShowOnHome(id);
            return Json("Updated Succefully");
        }
        #endregion
        #region State City
        public ActionResult AddState(int id = 0)
        {
            var model = new State();
            if (id > 0)
            {
                model = _commonDal.GetStateList(id).FirstOrDefault();
                if (model == null)
                {
                    model = new State();
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddState(State model)
        {
            _commonDal.SaveOrUpdateState(model);
            return Json("State Saved Succefully");
        }
        public ActionResult StateList()
        {
            var list = _commonDal.GetStateList();
            return View(list);
        }
        [HttpPost]
        public ActionResult DeleteState(int id)
        {
            var list = _commonDal.DeleteStateById(id);
            return Json(1);
        }
        public ActionResult AddCity(int id = 0)
        {
            var model = new City();
            if (id > 0)
            {
                model = _commonDal.GetCityList(id).FirstOrDefault();
                if (model == null)
                {
                    model = new City();
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCity(City model)
        {
            _commonDal.SaveOrUpdateCity(model);
            return Json("City Saved Succefully");
        }
        public ActionResult CityList()
        {
            var list = _commonDal.GetCityList();
            return View(list);
        }
        [HttpPost]
        public ActionResult DeleteCity(int id)
        {
            var list = _commonDal.DeleteCityById(id);
            return Json(1);
        }
        #endregion
    }
}