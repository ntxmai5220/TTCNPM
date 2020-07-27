using BKFoodCourt.DatabaseAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.DatabaseAccess.Dao
{
    public class FoodDao
    {
        EF.BKFoodCourt db = null;
        public FoodDao()
        {
            db = new EF.BKFoodCourt();
        }
        public List<Food> search(string search)
        {
            List<Food> food = db.Foods.Where(x => x.Name.Contains(search) || search == null).ToList();
            return food;
        }

        public Food getById(int id)
        {
            Food food = db.Foods.SingleOrDefault(x => x.ID == id);
            return food;
        }

        public int Insert(Food entity)
        {
            try
            {
                db.Foods.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(Food entity)
        {
            try
            {
                db.Foods.AddOrUpdate(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}