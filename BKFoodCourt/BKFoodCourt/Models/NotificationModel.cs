using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class NotificationModel
    {
        public List<Notification> notification = null;

        public bool check { set; get; }

        public NotificationModel()
        {
            notification = new List<Notification>();
        }
    }
}