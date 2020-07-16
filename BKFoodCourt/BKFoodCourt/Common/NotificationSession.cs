using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Common
{
    public class NotificationSession
    {
        List<Notification> notification = null;
        bool check;
        public NotificationSession()
        {
            notification = new List<Notification>();
            check = false;
        }
    }
}