using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.DatabaseAccess.Dao
{
    public class UserDao
    {
        EF.BKFoodCourt db = null;
        public UserDao()
        {
            db = new EF.BKFoodCourt();
        }

        public int InsertAcc(Account entity)
        {
            //Check
            if (db.Accounts.SingleOrDefault(x => x.Email == entity.Email) == null)
            {
                db.Accounts.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return -1;
            }

        }
        public int Login(string email, string password)
        {
            Account acc = db.Accounts.SingleOrDefault(x => x.Email == email);
            if (acc != null)
            {
                acc.PassWord = acc.PassWord.Trim();
                password = password.Trim();
                if (acc.PassWord == password)
                {
                    return acc.TypeAccount;
                }
                else
                {
                    return -1;
                }
            }
            else
                return -1;
        }

        public Account GetInfo(string email)
        {
            Account acc = db.Accounts.SingleOrDefault(x => x.Email == email);
            return acc;
        }

        public int UpdateInfo(Account account, string oldPassword)
        {
            Account acc;
            if ((acc = GetInfo(account.Email)) != null)
            {
                acc.PassWord = acc.PassWord.Trim();
                if (acc.PassWord == oldPassword)
                {
                    if (account.Name != null) acc.Name = account.Name;
                    if (account.PassWord != null) acc.PassWord = account.PassWord;
                    db.Accounts.AddOrUpdate(acc);
                    db.SaveChanges();
                    return 1;
                }
                else return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}