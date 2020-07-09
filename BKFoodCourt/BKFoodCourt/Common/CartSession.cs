using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Common
{
    [Serializable]
    public class CartSession
    {
        public Dictionary<int, int> cart = null;

        public CartSession()
        {
            cart = new Dictionary<int, int>();
        }
    }
}