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
    public class CustomerController : Controller
    {
        // GET: Customer
        public void loadNotification()
        {
            LoginModel user = Session[CommonConstant.USER_SESSION] as LoginModel;
            var dao = new NotificationDao();
            List<Notification> notifications = dao.getNotifications(user.ID);
            Session[CommonConstant.NOTIFICATION_SESSION] = new NotificationModel();
            NotificationModel notificationModel = Session[CommonConstant.NOTIFICATION_SESSION] as NotificationModel;
            foreach (var item in notifications)
            {
                notificationModel.notification.Add(item);
            }
        }

        private bool check()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 0)
            {
                return false;
            }
            loadNotification();
            return true;
        }

        public ActionResult Index()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult Contact()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult UserInfo()
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
                        return RedirectToAction("UserInfo");
                    }
                    if (res == 0)
                    {
                        ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                    }
                    if (res == -1)
                    {
                        ModelState.AddModelError("", "Lỗi cập nhật!");
                    }
                }
            }
            return RedirectToAction("UpdateInfo");
        }

        public ActionResult Order(int CustomerID)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<DonHang> res = dao.getDonHangOfCustomer(CustomerID);
            return View(res);
        }

        public ActionResult OrderDetail(int OrderID)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<OrderDetail> res = dao.getInfoOrder(OrderID);
            return View(res);
        }

        public ActionResult NotificationDetail(int ID)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            var Dao = new NotificationDao();
            Notification notification = Dao.GetNotification(ID);
            List<OrderDetail> res = dao.getInfoOrder(notification.DonHang.ID);
            notification.State = true;
            Dao.UpdateNotificationDao(notification);
            return View(res);
        }
        public ActionResult Notification()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}