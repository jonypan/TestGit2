using Extend.DataAccess.DTO;
using Hanvet.Areas.Admin.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hanvet.Areas.Admin.Controllers
{
    [Authorize]
    public class BaseController<T> : Controller
    {
        private string UrlCode = "";
        public BaseController()
        {
        }
        public BaseController(string url)
        {
            UrlCode = url;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" }));
                base.OnActionExecuting(filterContext);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Create(T model)
        {
            AdminSession adminsession = SessionHelper.getAdminSession();
            Menu menu = adminsession.FindMenu(UrlCode);
            if (menu == null || !menu.IsInsert)
            {
                TempData["ErrorMessage"] = "Bạn không có quyền Insert dữ liệu!";
                return RedirectToAction("Error", "Home");
            }
            return CreateRewrite(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Edit(T model)
        {
            AdminSession adminsession = SessionHelper.getAdminSession();
            Menu menu = adminsession.FindMenu(UrlCode);
            if (menu == null || !menu.IsUpdate)
            {
                TempData["ErrorMessage"] = "Bạn không có quyền Update dữ liệu!";
                return RedirectToAction("Error", "Home");
            }
            return EditRewrite(model);
        }

        public virtual ActionResult Delete(T model)
        {
            AdminSession adminsession = SessionHelper.getAdminSession();
            Menu menu = adminsession.FindMenu(UrlCode);
            if (menu == null || !menu.IsDelete)
            {
                TempData["ErrorMessage"] = "Bạn không có quyền Xóa dữ liệu!";
                return RedirectToAction("Error", "Home");
            }
            return DeleteRewrite(model);
        }
        public virtual ActionResult CreateRewrite(T model)
        {
            return View();
        }
        public virtual ActionResult EditRewrite(T model)
        {
            return View();
        }
        public virtual ActionResult DeleteRewrite(T model)
        {
            return View();
        }
    }
}