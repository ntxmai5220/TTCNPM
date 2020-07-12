using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;
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
        // GET: Menu
        public ActionResult Index(string search,int? page)
        {
            var dao = new FoodDao();
            List<Food> foodList = dao.search(search);
            return View(foodList.ToPagedList(page ?? 1,8));
        }
    }
}