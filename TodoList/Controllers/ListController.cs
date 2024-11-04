using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace TodoList.Controllers
{
    public class ListController : Controller
    {
        private TodolistDbContext _db = new TodolistDbContext();

        public ActionResult Index(int ListID)
        {
            string email = Session["Email"].ToString();
            var tasks = _db.Tasks.Where(t => t.ListID == ListID && t.Email == email && t.Deleted == 0).ToList();
            var ListName = _db.Lists.Where(t => t.ListID == ListID && t.Email == email && t.Deleted == 0).FirstOrDefault().ListName;
            ViewBag.ListID = ListID;
            ViewBag.ListName = ListName;
            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string ListName, string BgColor)
        {
            if (ModelState.IsValid)
            {
                var email = Session["Email"].ToString();
                List list = new List();
                list.ListName = ListName;
                list.BgColor = BgColor;
                list.Email = email;
                list.CreatedAt = DateTime.Now;
                list.Deleted = 0;

                _db.Lists.Add(list);
                _db.SaveChanges();
                var lists = _db.Lists.Where(t => t.Email == email && t.Deleted == 0).ToList();
                Session.Add("Lists", lists);
            }
            return RedirectPermanent("/");
        }

        public ActionResult AddTask(string TaskName, int ListID)
        {
            if (ModelState.IsValid)
            {
                Task task = new Task();
                string email = (string)Session["Email"];

                task.TaskTitle = TaskName;
                task.TaskDescription = "";
                task.Upcoming = "today";
                task.ListID = ListID;
                task.Email = email;
                task.CreatedAt = DateTime.Now;
                task.Deleted = 0;

                _db.Tasks.Add(task);
                _db.SaveChanges();

                int UpcomingQty = _db.Tasks.Where(t => t.Email == email && t.Deleted == 0).Count();
                int TodayQty = _db.Tasks.Where(t => t.Email == email && t.Upcoming == "today" && t.Deleted == 0).Count();
                Session.Add("UpcomingQty", UpcomingQty);
                Session.Add("TodayQty", TodayQty);

                return RedirectPermanent("/List/Index?ListID=" + ListID);
            }
            return RedirectPermanent("/List/Index?ListID=" + ListID);
        }

        public ActionResult Delete(int ListID)
        {
            string email = (string)Session["Email"];
            var tasks = _db.Tasks.Where(t => t.ListID == ListID && t.Email == email && t.Deleted == 0).ToList();
            var list = _db.Lists.Where(l => l.ListID == ListID && l.Deleted == 0).FirstOrDefault();

            foreach (var item in tasks)
            {
                _db.Tasks.Remove(item);
            }

            _db.Lists.Remove(list);
            _db.SaveChanges();
            var lists = _db.Lists.Where(t => t.Email == email && t.Deleted == 0).ToList();
            Session.Add("Lists", lists);

            return RedirectPermanent("/");
        }
    }
}