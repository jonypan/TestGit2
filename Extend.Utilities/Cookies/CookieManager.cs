using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Extend.Utilities.Cookies
{
    public class CookieManager
    {
        public static void RemoveAllCookies(bool removeSesstionCookie)
        {
            HttpContext.Current.Response.Cookies.Clear();

            //foreach (string cookie in HttpContext.Current.Request.Cookies.AllKeys)
            //{
            //    HttpContext.Current.Response.Cookies.Set(new HttpCookie(cookie) { Expires = DateTime.Now.AddMonths(-1), Path = "/" });
            //}

            //HttpContext.Current.Response.Cookies.Set(new HttpCookie(cookie) { Expires = DateTime.Now.AddMonths(-1), Path = "/" });
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;

            if (cookies == null || cookies.Length == 0)
                return;

            foreach (string cookie in cookies)
            {
                //Thêm cookie đã expire nếu có config Cookie Domain trong FormsAuthentication của web.config
                if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain) && cookie.Equals(FormsAuthentication.FormsCookieName))
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookie)
                    {
                        Name = FormsAuthentication.FormsCookieName,
                        Domain = FormsAuthentication.CookieDomain,
                        Expires = DateTime.Now.AddYears(-1)
                    });
                }

                //if (cookie == FormsAuthentication.FormsCookieName) continue;
                //if (cookie == SSO_SESSION_COOKIES && !removeSesstionCookie) continue;
                //if (!cookie.ToLower().Contains("sso")) continue;
                try
                {
                    //lấy cookie có sẵn
                    HttpCookie httpCookie = HttpContext.Current.Request.Cookies[cookie];
                    if (httpCookie != null)
                    {
                        //set expires cho cookie
                        httpCookie.Domain = HttpContext.Current.Request.Url.Host.Contains("localhost") ? null : "." + HttpContext.Current.Request.Url.Host; ;
                        httpCookie.Expires = DateTime.Now.AddYears(-1);
                        //update cookie
                        HttpContext.Current.Response.Cookies.Set(httpCookie);
                    }

                    if (removeSesstionCookie)
                    {
                        HttpContext.Current.Request.Cookies.Remove(cookie);
                    }
                }
                catch (Exception ex){
                    NLogManager.PublishException(ex);
                }

            }
            //if (!string.IsNullOrEmpty(CookieDomain))
            //{
            //    foreach (string cookie in HttpContext.Current.Request.Cookies.AllKeys)
            //    {
            //        if (cookie == FormsAuthentication.FormsCookieName) continue;
            //        if (cookie == SSO_SESSION_COOKIES && !removeSesstionCookie) continue;
            //        if (!cookie.Contains("sso")) continue;
            //        HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookie) { Expires = DateTime.Now.AddMonths(-1), Domain = CookieDomain.Trim(), Path = "/" });
            //    }
            //}
        }
    }
}