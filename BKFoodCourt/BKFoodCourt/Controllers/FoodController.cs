using BKFoodCourt.Common;
using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;
using BKFoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BKFoodCourt.Controllers
{
    public class FoodController : Controller
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
        // GET: Food
        public ActionResult Detail(int foodId)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new FoodDao();
            Food food = dao.getById(foodId);
            return View(food);
        }
    }
}