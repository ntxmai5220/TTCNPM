﻿using BKFoodCourt.Common;
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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult Report()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<DonHang> res = dao.getReport();
            return View(res);
        }

        public ActionResult UpdateMenu()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult Statistic()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult AdminInfo()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult CreateAccount()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}