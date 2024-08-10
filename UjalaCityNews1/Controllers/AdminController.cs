using System;
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
    public class AdminController : Controller
    {
        private readonly CommonDAL _commonDal = new CommonDAL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPostList()
        {
            var list = _commonDal.GetNewsPostsByName();
            return PartialView("_PostList", list);
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
    }
}