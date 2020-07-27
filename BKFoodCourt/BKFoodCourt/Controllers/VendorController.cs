using BKFoodCourt.Common;
using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;
using BKFoodCourt.Models;
using PagedList;
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
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        //GET:Update
        public ActionResult UpdateMenu(string search, int? page)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new FoodDao();
            List<Food> foodList = dao.search(search);
            return View(foodList.ToPagedList(page ?? 1, 8));
        }

        public ActionResult UpdateItem(int foodId)
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new FoodDao();
            Food food = dao.getById(foodId);
            return View(food);
        }

        public ActionResult UpdateItemAction(Food model)
        {
            FoodDao dao = new FoodDao();
            if (ModelState.IsValid)
            {
                if (dao.Update(model) >= 0)
                {
                    return RedirectToAction("UpdateMenu");
                }    
                else
                {
                    ModelState.AddModelError("", "Lỗi cập nhật");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng điền đủ và chính xác các trường.");
            }
            return View("UpdateItem", new { foodId = model.ID });

        }

        public ActionResult AddFood()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult AddFoodAction(Food food)
        {
            FoodDao dao = new FoodDao();
            if (ModelState.IsValid)
            {
                if (dao.Update(food) >= 0)
                {
                    return RedirectToAction("UpdateMenu");
                }    
                else
                {
                    ModelState.AddModelError("", "");
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            return View("AddFood");
        }

        public ActionResult VendorInfo()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            LoginModel login = Session[CommonConstant.USER_SESSION] as LoginModel;
            return View(login);
        }

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
                model.TypeAccount = 2;
                UserDao dao = new UserDao();
                if (dao.InsertAcc(model) > 0)
                {
                    return RedirectToAction("Index", "Vendor");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi!");
                }
            }
            else
                ModelState.AddModelError("", "Vui lòng điền đầy đủ các trường.");
            return View("CreateAccount","Vendor");
        }

        public ActionResult Report()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            var dao = new OrderDao();
            List<ListOrderModel> res = new List<ListOrderModel>();
            List<DonHang> listOrder = new List<DonHang>();
            listOrder = dao.getOrderFinsh();
            foreach (var item in listOrder)
            {
                ListOrderModel order = new ListOrderModel();
                order.ID = item.ID;
                order.OrderCode = item.OrderCode;
                order.CustomerID = item.CustomerID;
                order.Price = item.Price;
                order.Timer = item.Timer;
                order.State = item.State;
                List<OrderDetail> tmp = dao.getInfoOrder(item.ID);
                foreach (var i in tmp)
                {
                    order.list.Add(i.FoodID, i.Quantily);
                }
                res.Add(order);
            }
            return View(res);
        }

        public ActionResult Statistic()
        {
            if (!check())
            {
                return RedirectToAction("Login", "User");
            }
            StatisticModel res = new StatisticModel();
            StatisticDao dao = new StatisticDao();
            res.NumCustomerOrder = dao.NumCustomerOrder();
            res.NumFoodOrder = dao.NumFoodOrder();
            res.NumOrder = dao.NumOrder();
            res.listFoodOrder = dao.getListFoodOrder();
            return View(res);
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
                        return RedirectToAction("VendorInfo");
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
    }
}