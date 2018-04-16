using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extend.DataAccess.DTO;
using Hanvet.Models;
using Extend.DataAccess;

namespace Hanvet.Code
{
    public class SessionHelper
    {
        public static CategoryContainer getCateSession()
        {
            var cate = HttpContext.Current.Session["CateSession"];
            if (cate == null)
            {
                CategoryContainer getCate = new CategoryContainer();
                List<Category> list = ADODAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
                getCate.cateList = list;
                SessionHelper.setCateSession(getCate);
                return getCate;
            }
            return (CategoryContainer)cate;
        }
        public static void setCateSession(CategoryContainer cate)
        {
            HttpContext.Current.Session["CateSession"] = cate;
        }
        public static void removeCateSession()
        {
            HttpContext.Current.Session["CateSession"] = null;
        }
        public static string getLanguageSession()
        {
            var lang = HttpContext.Current.Session["Language"];
            if (lang != null)
                return (string)lang;
            return "vi";
        }
        public static void setLanguageSession(string lang)
        {
            HttpContext.Current.Session["Language"] = lang;
        }
    }
}