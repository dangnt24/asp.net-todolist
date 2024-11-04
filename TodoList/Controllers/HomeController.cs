using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ToDoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private TodolistDbContext _db = new TodolistDbContext();

        public ActionResult Today()
        {
            var email = Session["Email"];

            if (email != null)
            {
                var tasks = _db.Tasks.Where(t => t.Email == email.ToString() && t.Upcoming == "today" && t.Deleted == 0).ToList();
                return View(tasks);
            } else
            {
                return RedirectPermanent("/Account/Login");
            }
        }

        public ActionResult Upcoming()
        {
            var email = Session["Email"];
            if (email == null)
            {
                return RedirectPermanent("/Account/Login");
            }

            dynamic mymodel = new ExpandoObject();
            mymodel.today = _db.Tasks.Where(t => t.Email == email.ToString() && t.Upcoming == "today" && t.Deleted == 0).ToList();
            mymodel.tomorrow = _db.Tasks.Where(t => t.Email == email.ToString() && t.Upcoming == "tomorrow" && t.Deleted == 0).ToList();
            mymodel.thisweek = _db.Tasks.Where(t=> t.Email == email.ToString() && t.Upcoming == "thisweek" && t.Deleted == 0).ToList();
            return View(mymodel);
        }

        public ActionResult StickyWall()
        {
            var email = Session["Email"];
            if (email == null)
            {
                return RedirectPermanent("/Account/Login");
            }

            var st = _db.StickyWalls.Where(s => s.Email == email.ToString() && s.Deleted == 0).ToList();
            return View(st);
        }
    }
}