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
    public class CookController : Controller
    {
        public void loadNotification()
        {
            Session[CommonConstant.NOTIFICATION_SESSION] = new NotificationModel();
            NotificationModel notificationModel = Session[CommonConstant.NOTIFICATION_SESSION] as NotificationModel;
            var dao = new NotificationDao();
            if (dao.getNumDonHang() == 0)
            {
                notificationModel.check = false;
            }
            else
            {
                notificationModel.check = true;
            }
        }

        private bool check()
        {
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            if (login == null || login.typeAcc != 2)
            {
                return false;
            }
            return true;
        }
        // GET: Cook
        public ActionResult Index()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            loadNotification();
            return View();
        }
        //GET: OrderList
        public ActionResult OrderList()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<ListOrderModel> res = new List<ListOrderModel>();
            List<DonHang> listOrder = new List<DonHang>();
            listOrder = dao.getOrderList();
            foreach (var item in listOrder)
            {
                ListOrderModel order = new ListOrderModel();
                order.ID = item.ID;
                order.OrderCode = item.OrderCode;
                order.CustomerID = item.CustomerID;
                order.Price = item.Price;
                order.Timer = item.Timer;
                order.State = 0;
                List<OrderDetail> tmp = dao.getInfoOrder(item.ID);
                foreach (var i in tmp)
                {
                    order.list.Add(i.FoodID, i.Quantily);
                }
                res.Add(order);
            }
            return View(res);
        }

        public ActionResult Cancel(int ID)
        {
            var dao = new OrderDao();
            DonHang item = dao.getOrder(ID);
            item.State = 2;
            dao.UpdateOrder(item);
            //
            Notification notification = new Notification();
            notification.CustomerID = item.CustomerID;
            notification.DonHangID = item.ID;
            notification.Infomation = "đã bị hủy";
            notification.State = false;
            notification.Timer = DateTime.Now;
            var Dao = new NotificationDao();
            Dao.AddNotificationDao(notification);

            return RedirectToAction("OrderList", "Cook");
        }

        public ActionResult Process(int ID)
        {
            var dao = new OrderDao();
            List<OrderDetail> res = dao.getInfoOrder(ID);
            return View(res);
        }

        public ActionResult Finish(int ID)
        {
            var dao = new OrderDao();
            DonHang item = dao.getOrder(ID);
            item.State = 1;
            dao.UpdateOrder(item);

            //
            Notification notification = new Notification();
            notification.CustomerID = item.CustomerID;
            notification.DonHangID = item.ID;
            notification.Infomation = "đã hoàn thành";
            notification.State = false;
            notification.Timer = DateTime.Now;
            var Dao = new NotificationDao();
            Dao.AddNotificationDao(notification);
            return RedirectToAction("OrderList", "Cook");
        }
        
        //GET: OrderInfo
        public ActionResult CookInfo()
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
                        return RedirectToAction("CookInfo");
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

    }
}