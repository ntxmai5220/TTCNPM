using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class StatisticModel
    {
        //Statistic Admin
        public int NumCustomer { set; get; }
        public int NumFood { set; get; }
        public int NumOrderSuccess { set; get; }
        public int NumOrderCancel { set; get; }

        //Stastic Vendor
        public int NumCustomerOrder { set; get; }
        public int NumFoodOrder { set; get; }
        public int NumOrder { set; get; }
        public Dictionary<Food,int> listFoodOrder { set; get; }
    }
}