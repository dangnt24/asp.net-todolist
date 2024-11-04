using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ToDoList.Models;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {
        private TodolistDbContext _db = new TodolistDbContext();

        // GET: Task
        public ActionResult Add(string Upcoming, string TaskName)
        {
            if (ModelState.IsValid && TaskName != "" && TaskName != null)
            {
                if (Upcoming == "Home")
                {
                    Task task = new Task();
                    string email = (string)Session["Email"];

                    task.TaskTitle = TaskName;
                    task.TaskDescription = "";
                    task.Upcoming = "today";
                    task.ListID = _db.Lists.FirstOrDefault(l => l.ListName == "None" && l.Email == email && l.Deleted == 0).ListID;
                    task.Email = email;
                    task.CreatedAt = DateTime.Now;
                    task.Deleted = 0;

                    _db.Tasks.Add(task);
                    _db.SaveChanges();

                    int UpcomingQty = _db.Tasks.Where(t => t.Email == email && t.Deleted == 0).Count();
                    int TodayQty = _db.Tasks.Where(t => t.Email == email && t.Upcoming == "today" && t.Deleted == 0).Count();
                    Session.Add("UpcomingQty", UpcomingQty);
                    Session.Add("TodayQty", TodayQty);

                    return RedirectPermanent("/");
                }
                else
                {
                    Task task = new Task();
                    string email = (string)Session["Email"];

                    task.TaskTitle = TaskName;
                    task.TaskDescription = "";
                    task.Upcoming = Upcoming;
                    task.ListID = _db.Lists.FirstOrDefault(l => l.ListName == "None" && l.Email == email && l.Deleted == 0).ListID;
                    task.Email = email;
                    task.CreatedAt = DateTime.Now;
                    task.Deleted = 0;

                    _db.Tasks.Add(task);
                    _db.SaveChanges();

                    int UpcomingQty = _db.Tasks.Where(t => t.Email == email && t.Deleted == 0).Count();
                    int TodayQty = _db.Tasks.Where(t => t.Email == email && t.Upcoming == "today" && t.Deleted == 0).Count();
                    Session.Add("UpcomingQty", UpcomingQty);
                    Session.Add("TodayQty", TodayQty);

                    return RedirectPermanent("/Home/Upcoming");
                }
            }
            return RedirectPermanent("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task, string isHome, HttpPostedFileBase img)
        {
            if(ModelState.IsValid)
            {
                Task taskUpdate = _db.Tasks.Where(t => t.TaskID == task.TaskID && t.Deleted == 0).FirstOrDefault();
                taskUpdate.TaskTitle = task.TaskTitle;
                taskUpdate.TaskDescription = task.TaskDescription;
                taskUpdate.DueDate = task.DueDate;
                taskUpdate.ListID = (int) task.ListID;
                taskUpdate.UpdatedAt = DateTime.Now;

                string taskImage = task.TaskImage;
                try
                {
                    if (img != null && img.ContentLength > 0 ) {
                        string _filename = "IMG_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + "_" + Path.GetFileName(img.FileName).ToString().Replace(" ", "_");
                        string _path = Path.Combine(Server.MapPath("~/Images"), _filename);
                        img.SaveAs(_path);
                        if (taskImage == "" || taskImage == null)
                        {
                            taskImage += _filename;
                        } else
                        {
                            taskImage += "--dvp--" + _filename;
                        }
                    }
                } catch
                {
                    return RedirectPermanent("/");
                }

                taskUpdate.TaskImage = taskImage;
                _db.SaveChanges();

                if (isHome == "yes")
                {
                    return RedirectPermanent("/");
                } else if (isHome == "list") { 
                    return RedirectPermanent("/List/Index?ListID=" + task.ListID);
                } else
                {
                    return RedirectPermanent("/Home/Upcoming");
                }
            }
            return View(task);
        }

        public ActionResult DeleteTask(int id, string isHome)
        {
            var task = _db.Tasks.Where(t => t.TaskID == id && t.Deleted == 0).FirstOrDefault();
            var ListID = task.ListID;
            string email = (string)Session["Email"];
            _db.Tasks.Remove(task);
            _db.SaveChanges();

            int UpcomingQty = _db.Tasks.Where(t => t.Email == email && t.Deleted == 0).Count();
            int TodayQty = _db.Tasks.Where(t => t.Email == email && t.Upcoming == "today" && t.Deleted == 0).Count();
            Session.Add("UpcomingQty", UpcomingQty);
            Session.Add("TodayQty", TodayQty);

            if (isHome == "yes")
            {
                return RedirectPermanent("/");
            }
            else if (isHome == "list")
            {
                return RedirectPermanent("/List/Index?ListID=" + ListID);
            }
            else
            {
                return RedirectPermanent("/Home/Upcoming");
            }
            return RedirectPermanent("/");
        }
    }
}