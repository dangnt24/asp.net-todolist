using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace TodoList.Controllers
{
    public class StickyWallController : Controller
    {
        private TodolistDbContext _db = new TodolistDbContext();

        [HttpPost]
        public ActionResult Add(string SwTitle, string SwDescription, string BgColor)
        {
            if (ModelState.IsValid)
            {
                string email = Session["Email"].ToString();
                StickyWall sw = new StickyWall();
                sw.SwTitle = SwTitle;
                sw.SwDescription = SwDescription;
                sw.BgColor = BgColor;
                sw.Email = email;
                sw.CreatedAt = DateTime.Now;
                sw.Deleted = 0;

                _db.StickyWalls.Add(sw);
                _db.SaveChanges();
            }
            return RedirectPermanent("/Home/StickyWall");
        }

        [HttpPost]
        public ActionResult UpdateContent(StickyWall sw)
        {
            if (ModelState.IsValid)
            {
                StickyWall swUpdate = _db.StickyWalls.Where(s => s.SwID == sw.SwID && s.Deleted == 0).FirstOrDefault();
                swUpdate.SwTitle = sw.SwTitle;
                swUpdate.SwDescription = sw.SwDescription;
                swUpdate.UpdatedAt = DateTime.Now;
                _db.SaveChanges();
            }
            return RedirectPermanent("/Home/StickyWall");
        }

        public ActionResult UpdateColor(StickyWall sw)
        {
            if (ModelState.IsValid)
            {
                var swUpdate = _db.StickyWalls.Where(s => s.SwID == sw.SwID && s.Deleted == 0).FirstOrDefault();
                swUpdate.BgColor = sw.BgColor;
                swUpdate.UpdatedAt = DateTime.Now;
                _db.SaveChanges();
            }
            return RedirectPermanent("/Home/StickyWall");
        }

        public ActionResult Delete(int SwID)
        {
            if (ModelState.IsValid)
            {
                StickyWall sw = _db.StickyWalls.Where(s => s.SwID == SwID && s.Deleted == 0).FirstOrDefault();
                _db.StickyWalls.Remove(sw);
                _db.SaveChanges();
            }
            return RedirectPermanent("/Home/StickyWall");
        }
    }
}