using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoList.Controllers
{
    public class SubTaskController : Controller
    {
        // GET: SubTask
        public ActionResult Index()
        {
            return View();
        }
    }
}