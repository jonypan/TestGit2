using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hanvet.Areas.Admin.Controllers
{
    public class HomeController : BaseController<Object>
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            return View();
        }
    }
}