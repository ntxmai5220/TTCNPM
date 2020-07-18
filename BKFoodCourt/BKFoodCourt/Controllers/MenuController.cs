using BKFoodCourt.Common;
using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;
using BKFoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BKFoodCourt.Controllers
{
    public class MenuController : Controller
    {
        private bool check()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 0)
            {
                return false;
            }
            return true;
        }
        // GET: Menu
        public ActionResult Index(string search,int? page)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new FoodDao();
            List<Food> foodList = dao.search(search);
            return View(foodList.ToPagedList(page ?? 1,8));
        }
    }
}