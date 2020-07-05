﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BKFoodCourt.Models
{
    public class ListOrder
    {
        public Dictionary<int, int> list;

        public ListOrder()
        {
            list = new Dictionary<int, int>();
        }

        public void Add(int id)
        {
            if (list.ContainsKey(id))
            {
                list[id]++;
            }
            else
            {
                list.Add(id, 1);
            }
        }

        public void Remove(int id)
        {
            list.Remove(id);
        }

        public void changeQuantity(int id,int quantity)
        {
            if (quantity <= 0)
            {
                Remove(id);
            }
            else
            {
                list[id] = quantity;
            }
        }

        private Food findFood(int id)
        {
            DataTable dataTable = new DataTable();

            string connString = @"Data Source=DESKTOP-C8J1S1O\SQLEXPRESS;Initial Catalog=BKFOODCOURT;Integrated Security=True";
            string query = "select * from Food where ID = @id";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@id", id);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            Food res = new Food();
            try
            {
                foreach (var row in dataTable.AsEnumerable())
                {
                    Food obj = new Food();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    res = obj;
                }
            }
            catch
            {

            }
            return res;
        }
    }
}