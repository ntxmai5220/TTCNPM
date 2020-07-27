using BKFoodCourt.DatabaseAccess.Dao;
using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class ListOrderModel
    {
        public int ID { set; get; }
        public string OrderCode { set; get; }
        public int CustomerID { set; get; }
        public Dictionary<int, int> list = new Dictionary<int, int>();
        public int Price { set; get; }
        public DateTime Timer { set; get; }
        public int State { set; get; }

        public Food getFood(int id)
        {
            var dao = new FoodDao();
            Food food = dao.getById(id);
            return food;
        }
    }
}