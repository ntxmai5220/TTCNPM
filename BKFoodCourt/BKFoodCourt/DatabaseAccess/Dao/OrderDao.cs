using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.DatabaseAccess.Dao
{
    public class OrderDao
    {
        EF.BKFoodCourt db = null;

        public OrderDao()
        {
            db = new EF.BKFoodCourt();
        }

        // See History Order of Customer
        public List<DonHang> getDonHangOfCustomer(int CustomerID)
        {
            List<DonHang> res = db.DonHangs.Where(x => x.CustomerID == CustomerID).ToList();
            return res;
        }

        //See Report
        public List<DonHang> getReport()
        {
            List<DonHang> res = db.DonHangs.Where(x => x.State == true).ToList();
            return res;
        }

        //Food Detail
        public List<OrderDetail> getInfoOrder(int OrderID)
        {
            List<OrderDetail> res = db.OrderDetails.Where(x => x.OrderID == OrderID).ToList();
            return res;
        }

        //List Order
        public List<DonHang> getOrderList()
        {
            List<DonHang> res = db.DonHangs.Where(x => x.State == false).ToList();
            return res;
        }

        //Add DataBase
        public void AddOrder(DonHang item)
        {
            db.DonHangs.Add(item);
            db.SaveChanges();
        }

        public void AddOrderDetail(OrderDetail item)
        {
            db.OrderDetails.Add(item);
            db.SaveChanges();
        }
        
        public int getOrderID()
        {
            List<DonHang> tmp = db.DonHangs.ToList();
            DonHang item = tmp.ElementAt(tmp.Count - 1);
            return item.ID;
        }
    }
}