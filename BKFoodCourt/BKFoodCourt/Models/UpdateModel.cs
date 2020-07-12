using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BKFoodCourt.Models
{
    public class UpdateModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string NewPassword { get; set; }
        public string RetypePassword { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu để cập nhật!")]
        public string OldPassword { get; set; }
        public int ID { get; set; }
    }
}