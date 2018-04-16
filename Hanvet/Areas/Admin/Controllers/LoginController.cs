using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanvet.Models.Admin;
using Extend.DataAccess;
using Hanvet.Areas.Admin.Code;
using Extend.DataAccess.DTO;
using static Extend.Utilities.StringUtil;
using System.Web.Security;

namespace Hanvet.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin user)
        {
            int userID = ADODAOFactory.Instance().CreateAccountDao().User_Login(user.username, Encryptor.GetMD5(user.password));

            if (ModelState.IsValid && userID > 0)
            {
                AdminSession admin = new AdminSession() { userID = userID, username = user.username };
                List<Menu> menu = ADODAOFactory.Instance().CreateCommonDao().GetMenuByUserID(userID);
                admin.menu = menu;
                SessionHelper.setAdminSession(admin);

                FormsAuthentication.SetAuthCookie(user.username, user.remember);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}