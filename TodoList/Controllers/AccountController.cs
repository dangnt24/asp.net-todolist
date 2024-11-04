using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using System.IO;
using System.Web.Helpers;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        private TodolistDbContext _db = new TodolistDbContext();

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }

            return byte2String;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                string f_password = GetMD5(Password);
                var data = _db.Accounts.Where(s => s.Email == Email && s.Password == f_password && s.Deleted == 0).ToList();

                if (data.Count() > 0)
                {
                    string email = data.FirstOrDefault().Email;
                    var lists = _db.Lists.Where(t => t.Email == email && t.Deleted == 0).ToList();
                    int UpcomingQty = _db.Tasks.Where(t => t.Email == email && t.Deleted == 0).Count();
                    int TodayQty = _db.Tasks.Where(t => t.Email == email && t.Upcoming == "today" && t.Deleted == 0).Count();
                    Session.Add("Email", email);
                    Session.Add("Lists", lists);
                    Session.Add("UpcomingQty", UpcomingQty);
                    Session.Add("TodayQty", TodayQty);

                    return RedirectPermanent("/");
                } else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu không chính xác.";
                    return View();
                }

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _account)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Accounts.FirstOrDefault(s => s.Email == _account.Email && s.Deleted == 0);
                if (check == null)
                {
                    if (_account.Password != _account.ConfirmPassword) {
                        ViewBag.error = "Mật khẩu và xác nhận mật khảu phải giống nhau.";
                        return View();
                    }
                    _account.Password = GetMD5(_account.Password);
                    _account.CreatedAt = DateTime.Now;
                    _account.Deleted = 0;
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Accounts.Add(_account);

                    List DFList = new List();
                    DFList.ListName = "None";
                    DFList.BgColor = "#ccc";
                    DFList.Email = _account.Email;
                    DFList.CreatedAt = DateTime.Now;
                    _db.Lists.Add(DFList);

                    _db.SaveChanges();

                    return RedirectToAction("Login");
                } else
                {
                    ViewBag.error = "Email này đã tồn tại.";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}