using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Common
{
    [Serializable]
    public class UserSession
    {
        public int UserId { get; set; }

        public int Name { get; set; }
        public string Email { get; set; }
        public int typeAcc { get; set; }
    }
}