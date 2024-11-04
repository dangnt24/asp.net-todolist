using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class StickyWall
    {
        [Key]
        [DisplayName("Stiky Wall ID")]
        public int SwID { get; set; }

        [DisplayName("Tiêu đề")]
        public string SwTitle { get; set; }

        [DisplayName("Mô tả")]
        public string SwDescription { get; set; }

        [DisplayName("Màu hiển thị")]
        public string BgColor { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public byte Deleted { get; set; }

        [ForeignKey("Email")]
        public Account account { get; set; }
    }
}