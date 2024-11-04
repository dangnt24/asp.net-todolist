using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class Task
    {
        [Key]
        [DisplayName("Task ID")]
        public int TaskID { get; set; }

        [DisplayName("Tiêu đề")]
        public string TaskTitle { get; set; }

        [DisplayName("Mô tả")]
        public string TaskDescription { get; set; }

        [DisplayName("Ảnh")]
        public string TaskImage {  get; set; }

        [DisplayName("Sắp tới")]
        public string Upcoming { get; set; }

        [DisplayName("Thời Hạn")]
        public DateTime? DueDate { get; set; }

        [DisplayName("List ID")]
        public int ListID { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DefaultValue(0)]
        public byte Done { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public byte Deleted { get; set; }

        [ForeignKey("Email")]
        public Account account { get; set; }

        [ForeignKey("ListID")]
        public List list { get; set; }
    }
}