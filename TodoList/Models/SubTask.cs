using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class SubTask
    {
        [Key]
        [DisplayName("Sub Task ID")]
        public int StID { get; set; }

        [DisplayName("Tiêu đề")]
        public string StTitle { get; set; }

        [DisplayName("Mô tả")]
        public string StDescription { get; set; }

        [DisplayName("Ảnh")]
        public string StImage { get; set; }

        public DateTime? DueDate { get; set; }

        public int TaskID { get; set; }

        [ForeignKey("TaskID")]
        public Task task { get; set; }
    }
}