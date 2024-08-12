using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using UjalaCityNews1.DAL;
using UjalaCityNews1.Models;

namespace UjalaCityNews1.Controllers
{
    public class AccountController : Controller
    {
        private readonly CommonDAL _commonDal = new CommonDAL();
        // GET: Account
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(AddUser user)
        {
            _commonDal.InsertUser(user);
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var _login = _commonDal.VerifyUserLogin(login);
            if(_login == 1)
            {
                Session["UserId"] = _login;
                Session["Username"] = login.username;
            }
            return Json(_login);
        }
        public ActionResult Logout()
        {   
            Session.Clear(); // Clears the session
            return RedirectToAction("Login", "Home");
        }
    }
}