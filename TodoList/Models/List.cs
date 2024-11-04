using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class List
    {
        [Key]
        [DisplayName("List ID")]
        public int ListID { get; set; }

        [DisplayName("Tên Danh Sách")]
        public string ListName { get; set; }

        [DisplayName("Màu hiển thị")]
        public string BgColor { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public byte Deleted { get; set; }

        [ForeignKey("Email")]
        public Account account { get; set; }
    }
}