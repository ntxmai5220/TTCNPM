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
    public class AdminController : Controller
    {
        private bool check()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 1)
            {
                return false;
            }
            return true;
        }
        // GET: Admin
        public ActionResult Index()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        //GET::Report
        public ActionResult Report()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<DonHang> listOrder = new List<DonHang>();
            listOrder = dao.getReport();
            return View(listOrder);
        }

        public ActionResult ReportDetail(int OrderID)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<OrderDetail> res = dao.getInfoOrder(OrderID);
            return View(res);
        }

        //GET::Statistic
        public ActionResult Statistic()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            StatisticModel res = new StatisticModel();
            StatisticDao dao = new StatisticDao();
            res.NumCustomer = dao.NumCustomer();
            res.NumFood = dao.NumFood();
            res.NumOrderCancel = dao.NumOrderCancel();
            res.NumOrderSuccess = dao.NumOrderSuccess();
            return View(res);
        }

        //GET::AdminInfo
        public ActionResult AdminInfo()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            return View(login);
        }

        public ActionResult UpdateInfo()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            UpdateModel update = new UpdateModel();
            update.Name = login.Name;
            update.Email = login.Email;
            return View(update);
        }

        public ActionResult UpdateInfoAction(UpdateModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewPassword != null)
                    model.NewPassword = model.NewPassword.Trim();
                if (model.RetypePassword != null)
                    model.RetypePassword = model.RetypePassword.Trim();
                model.OldPassword = model.OldPassword.Trim();
                if (model.Name != null)
                    model.Name = model.Name.Trim();
                if (model.NewPassword == model.RetypePassword)
                {
                    UserDao dao = new UserDao();
                    Account acc = new Account();
                    acc.Name = model.Name;
                    acc.PassWord = model.NewPassword;
                    acc.Email = model.Email;
                    int res = dao.UpdateInfo(acc, model.OldPassword);
                    if (res == 1)
                    {
                        LoginModel user = Session[CommonConstant.USER_SESSION] as LoginModel;
                        user.Name = acc.Name;
                        return RedirectToAction("AdminInfo");
                    }
                    if (res == 0)
                    {
                        ModelState.AddModelError("", "Mật khẩu không đúng");
                    }
                    if (res == -1)
                    {
                        ModelState.AddModelError("", "Lỗi cập nhật!");
                    }
                }
            }
            return RedirectToAction("UpdateInfo");
        }

        //GET::Create Account
        public ActionResult CreateAccount()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult CreateAccountAction(Account model)
        {
            if (ModelState.IsValid)
            {
                model.TypeAccount = 3;
                UserDao dao = new UserDao();
                if (dao.InsertAcc(model) > 0)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ModelState.AddModelError("", "Lỗi!");
            }
            else
                ModelState.AddModelError("", "Vui lòng điền đầy đủ các trường.");
            return View("CreateAccount");
        }

    }
}