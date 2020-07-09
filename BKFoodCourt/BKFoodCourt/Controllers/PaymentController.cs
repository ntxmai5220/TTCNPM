using BKFoodCourt.Models.Momo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKFoodCourt.Models;
using BKFoodCourt.Common;
using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;

namespace BKFoodCourt.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        string endpoint;
        string partnerCode;
        string accessKey;
        string serectkey;
        string orderInfo;
        string returnUrl;
        string notifyurl;

        string amount;
        string orderid;
        string requestId;
        string extraData;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Momo()
        {
            endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            partnerCode = "MOMOREA420200703";
            accessKey = "QlGE6S9AlZNwni3M";
            serectkey = "JHt0d6lBW8pg1TNGFDLxTxG3MDTUMvbj";
            orderInfo = "Thanh toán MoMo";
            returnUrl = "https://momo.vn/return";
            notifyurl = "https://momo.vn/notify";

            amount = tongTien().ToString();
            orderid = Guid.NewGuid().ToString();
            requestId = Guid.NewGuid().ToString();
            extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            log.Debug("rawHash = " + rawHash);

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());

            AddOrder();
            AddOrderDetail();
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Cash()
        {
            endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            partnerCode = "MOMOREA420200703";
            accessKey = "QlGE6S9AlZNwni3M";
            serectkey = "JHt0d6lBW8pg1TNGFDLxTxG3MDTUMvbj";
            orderInfo = "Thanh toán MoMo";
            returnUrl = "https://momo.vn/return";
            notifyurl = "https://momo.vn/notify";

            amount = tongTien().ToString();
            orderid = Guid.NewGuid().ToString();
            requestId = Guid.NewGuid().ToString();
            extraData = "";

            AddOrder();
            AddOrderDetail();
            return RedirectToAction("Index", "Payment");
        }

        public long tongTien()
        {

            long sum = 0;
            CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
            for (int i = 0; i < cartModel.cart.Count; i++)
            {
                sum += cartModel.cart.ElementAt(i).Key.Price * cartModel.cart.ElementAt(i).Value;
            }
            return sum;
        }

        public void AddOrder()
        {
            var dao = new OrderDao();
            LoginModel loginModel = Session[CommonConstant.USER_SESSION] as LoginModel;
            CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
            DonHang item = new DonHang();
            item.OrderCode = orderid;
            item.NumFood = cartModel.cart.Count;
            item.CustomerID = loginModel.ID;
            item.Price = (int)tongTien();
            item.Timer = DateTime.Now;
            item.State = false;
            dao.AddOrder(item);
        }

        public void AddOrderDetail()
        {
            var dao = new OrderDao();
            CartModel cartModel = Session[CommonConstant.CART_SESSION] as CartModel;
            for (int i = 0; i < cartModel.cart.Count; i++)
            {
                var tmp = cartModel.cart.ElementAt(i);
                OrderDetail item = new OrderDetail();
                item.FoodID = tmp.Key.ID;
                item.Quantily = tmp.Value;
                item.OrderID = dao.getOrderID();
                dao.AddOrderDetail(item);
            }
        }
    }
}