using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string PassWord { get; set; }

        public int typeAcc { get; set; }

        public string Name { get; set; }

        public int ID { get; set; }
    }
}