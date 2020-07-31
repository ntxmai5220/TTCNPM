using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.DatabaseAccess.Dao
{
    public class NotificationDao
    {
        EF.BKFoodCourt db = null;

        public NotificationDao()
        {
            db = new EF.BKFoodCourt();
        }

        public void AddNotificationDao(Notification item)
        {
            db.Notifications.Add(item);
            db.SaveChanges();
        }

        public void UpdateNotificationDao(Notification item)
        {
            db.Notifications.AddOrUpdate(item);
            db.SaveChanges();
        }

        public List<Notification> getNotifications(int IDCustomer)
        {
            List<Notification> res = db.Notifications.Where(x => x.CustomerID == IDCustomer).ToList();
            return res;
        }

        public Notification GetNotification(int ID)
        {
            List<Notification> res = db.Notifications.Where(x => x.ID == ID).ToList();
            return res.ElementAt(0);
        }

        public int getNumDonHang()
        {
            List<DonHang> res = db.DonHangs.Where(x => x.State == 0).ToList();
            return res.Count;
        }

    }
}