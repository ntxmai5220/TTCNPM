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
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addToCart(int foodId)
        {
            if (Session[CommonConstant.CART_SESSION] == null)
            {
                Session[CommonConstant.CART_SESSION] = new CartModel();
            }
            CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
            bool flag = false;
            if (cartModel.cart != null)
            {
                for (int i = 0; i < cartModel.cart.Count; i++)
                {
                    if (cartModel.cart.ElementAt(i).Key.ID == foodId)
                    {
                        flag = true;
                        Food index = cartModel.cart.ElementAt(i).Key;
                        cartModel.cart[index]++;
                        break;
                    }
                }
            }
            if (!flag)
            {
                FoodDao dao = new FoodDao();
                Food foodItem = dao.getById(foodId);
                cartModel.cart.Add(foodItem, 1);
            }
            tongTien();
            return RedirectToAction("Index", "Cart");
        }
        public void tongTien()
        {
            if (Session[CommonConstant.CART_SESSION] != null)
            {
                long sum = 0;
                CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
                for (int i = 0; i < cartModel.cart.Count; i++)
                {
                    sum += cartModel.cart.ElementAt(i).Key.Price * cartModel.cart.ElementAt(i).Value;
                }
                cartModel.tongTien = sum;
            }
        }
        public RedirectToRouteResult suaSoLuong(int foodId, int soLuong)
        {
            if (Session[CommonConstant.CART_SESSION] != null)
            {
                CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
                if (cartModel.cart != null)
                {
                    for (int i = 0; i < cartModel.cart.Count; i++)
                    {
                        if (cartModel.cart.ElementAt(i).Key.ID == foodId)
                        {
                            Food index = cartModel.cart.ElementAt(i).Key;
                            if (soLuong <= 0)
                            {
                                cartModel.cart.Remove(index);
                            }
                            else
                                cartModel.cart[index] = soLuong;
                            break;
                        }
                    }
                }
            }
            tongTien();
            return RedirectToAction("Index", "Cart");
        }

        public RedirectToRouteResult deleteCart(int foodId)
        {
            if (Session[CommonConstant.CART_SESSION] != null)
            {
                CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
                if (cartModel.cart != null)
                {
                    for (int i = 0; i < cartModel.cart.Count; i++)
                    {
                        if (cartModel.cart.ElementAt(i).Key.ID == foodId)
                        {
                            Food index = cartModel.cart.ElementAt(i).Key;
                            cartModel.cart.Remove(index);
                            break;
                        }
                    }
                }
            }
            tongTien();
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Payment(FormCollection form)
        {
            int state = 0;
            bool ready = false;
            if (form["TypePayment"]==null)
            {
                ModelState.AddModelError("", "Bạn cần phải chọn phương thức thanh toán.");
                return View("Index");
            }

            string genderradio = form["TypePayment"].ToString();

            if (genderradio == "Cash")
            {
                state = 1;
            }
            if (genderradio == "Momo")
            {
                state = 2;
            }

            if (form["Accept"].ToString() == "false")
            {
                ready = false;
            }
            else
            {
                ready = true;
            }


            if (ready == true)
            {
                if (state == 1)
                {
                    return RedirectToAction("Cash", "Payment");
                }
                else
                {
                    return RedirectToAction("Momo", "Payment");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn cần phải chấp nhận điều khoản và chính sách để có thể thực hiện thanh toán.");
                return View("Index");
            }
        }
    }
}