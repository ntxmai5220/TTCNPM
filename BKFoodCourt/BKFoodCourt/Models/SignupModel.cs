using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Mời nhập lại mật khẩu")]
        public string RetypePassWord { get; set; }

        [Required(ErrorMessage = "Mời nhập tên")]
        public string Name { get; set; }
    }
}