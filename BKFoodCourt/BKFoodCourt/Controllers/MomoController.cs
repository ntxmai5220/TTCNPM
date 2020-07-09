using BKFoodCourt.Models.Momo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKFoodCourt.Models;
using BKFoodCourt.Common;

namespace BKFoodCourt.Controllers
{
    public class MomoController : Controller
    {
        // GET: Momo
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOREA420200703";
            string accessKey = "QlGE6S9AlZNwni3M";
            string serectkey = "JHt0d6lBW8pg1TNGFDLxTxG3MDTUMvbj";
            string orderInfo = "Thanh toán MoMo";
            string returnUrl = "https://momo.vn/return";
            string notifyurl = "https://momo.vn/notify";

            string amount = tongTien().ToString();
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

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

            return RedirectToAction("Index", "Cart");
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
    }
}