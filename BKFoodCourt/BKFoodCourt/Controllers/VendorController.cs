using BKFoodCourt.Common;
using BKFoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BKFoodCourt.Controllers
{
    public class VendorController : Controller
    {
        private bool check()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 3)
            {
                return false;
            }
            return true;
        }
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateMenu()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult VendorInfo()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult CreateAccount()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult Report()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult Statistic()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}