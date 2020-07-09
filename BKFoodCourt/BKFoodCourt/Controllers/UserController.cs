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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginAction(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                model.Email = model.Email.Trim();
                model.PassWord = model.PassWord.Trim();
                var dao = new UserDao();
                var result = dao.Login(model.Email, model.PassWord);
                var user = dao.GetInfo(model.Email);
                var userSession = new LoginModel();
                switch (result)
                {
                    case 0: //Customer
                        userSession.Email = user.Email;
                        userSession.typeAcc = 0;
                        userSession.Name = user.Name;
                        Session.Add(CommonConstant.USER_SESSION, userSession);

                        return RedirectToAction("Index", "Customer");
                    case 1: //Admin
                        userSession.Email = user.Email;
                        userSession.typeAcc = 1;
                        userSession.Name = user.Name;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Admin");
                    case 2: //Cook
                        userSession.Email = user.Email;
                        userSession.typeAcc = 2;
                        userSession.Name = user.Name;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Cook");
                    case 3:
                        userSession.Email = user.Email;
                        userSession.typeAcc = 3;
                        userSession.Name = user.Name;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Vendor");
                    default:
                        ModelState.AddModelError("", "Sai email hoặc mật khẩu.");
                        return View("Login");
                }
            }
            return View("Login");


        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult SignupAction(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                model.Email = model.Email.Trim();
                model.PassWord = model.PassWord.Trim();
                model.RetypePassWord = model.RetypePassWord.Trim();
                model.Name = model.Name.Trim();
                if (model.PassWord == model.RetypePassWord)
                {
                    var dao = new UserDao();
                    Account newacc = new Account();
                    newacc.Email = model.Email;
                    newacc.Name = model.Name;
                    newacc.PassWord = model.PassWord;
                    var result = dao.InsertAcc(newacc);
                    if (result >= 0)
                    {
                        return RedirectToAction("Login", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email đã tồn tại.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nhập lại mật khẩu không đúng.");
                }

            }
            return View("Signup");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}