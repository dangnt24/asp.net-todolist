using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Account
    {
        [Key]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mật Khẩu")]
        public string Password { get; set; }

        [DisplayName("Xác nhận mật Khẩu")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public byte Deleted { get; set; }

    }
}