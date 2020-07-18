using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.DatabaseAccess.Dao
{
    public class StatisticDao
    {
        EF.BKFoodCourt db = null;

        public StatisticDao()
        {
            db = new EF.BKFoodCourt();
        }

        public int NumCustomer()
        {
            return db.Accounts.Where(x => x.TypeAccount == 0).ToList().Count;
        }
        
        public int NumFood()
        {
            return db.Foods.ToList().Count;
        }

        public int NumOrderSuccess()
        {
            return db.DonHangs.Where(x => x.State == 1).ToList().Count;
        }

        public int NumOrderCancel()
        {
            return db.DonHangs.Where(x => x.State == 2).ToList().Count;
        }

        public int NumCustomerOrder()
        {
            List<int> check = new List<int>();
            var dao = new OrderDao();
            List<DonHang> list = dao.getOrderAll();
            foreach(var item in list)
            {
                List<OrderDetail> orders = dao.getInfoOrder(item.ID);
                foreach(var i in orders)
                {
                    if (check.Contains(i.FoodID) == false)
                    {
                        check.Add(i.FoodID);
                    }
                }
            }
            return check.Count;
        }

        public int NumFoodOrder()
        {
            List<int> check = new List<int>();
            var dao = new OrderDao();
            List<DonHang> list = dao.getOrderAll();
            foreach (var item in list)
            {
                if (check.Contains(item.CustomerID) == false)
                {
                    check.Add(item.CustomerID);
                }
            }
            return check.Count;
        }

        public int NumOrder()
        {
            List<DonHang> list = db.DonHangs.ToList();
            return list.Count;
        }
        public Dictionary<Food,int> getListFoodOrder()
        {
            var dao = new OrderDao();
            var convert = new FoodDao();
            List<DonHang> list = dao.getOrderAll();
            Dictionary<int, int> tmp = new Dictionary<int, int>();
            foreach(var item in list)
            {
                List<OrderDetail> orders = dao.getInfoOrder(item.ID);
                foreach(var i in orders)
                {
                    if (tmp.ContainsKey(i.FoodID) == true)
                    {
                        tmp[i.FoodID] += i.Quantily;
                    }
                    else
                    {
                        tmp.Add(i.FoodID, i.Quantily);
                    }
                }
            }
            Dictionary<Food, int> res = new Dictionary<Food, int>();
            foreach(var i in tmp)
            {
                res.Add(convert.getById(i.Key), i.Value);
            }
            return res;
        }
    }
}