using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using Extend.DataAccess.DAO;
using Hanvet.Code;

namespace Hanvet.Controllers
{
    
    public class TrangChuController : Controller
    {
        
        public ActionResult Index()
        {
            if (SessionHelper.getLanguageSession() == "en")
            {
                return RedirectToAction("TrangChuEn");
            }
            else
            {
                return RedirectToAction("TrangChuVn");
            }
        }
      
        public ActionResult TrangChuVn()
        {
            if (SessionHelper.getLanguageSession() != "vi")
                SessionHelper.removeCateSession();
            SessionHelper.setLanguageSession("vi");
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            IProduct dbProduct = ADODAOFactory.Instance().CreateProductDao();
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(2, 1, 10, out totalPage);
            List<Product> listProductByOrder = dbProduct.GetListProductByCate(3, 1, 10, out totalPage);

            ViewBag.listArticleByOrder = listArticleByOrder;
            ViewBag.listProductByOrder = listProductByOrder;
            return View();
        }
        public ActionResult TrangChuEn()
        {
            if (SessionHelper.getLanguageSession() != "en")
                SessionHelper.removeCateSession();
            SessionHelper.setLanguageSession("en");
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            IProduct dbProduct = ADODAOFactory.Instance().CreateProductDao();
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(22222, 1, 10, out totalPage);
            List<Product> listProductByOrder = dbProduct.GetListProductByCate(22223, 1, 10, out totalPage);

            ViewBag.listArticleByOrder = listArticleByOrder;
            ViewBag.listProductByOrder = listProductByOrder;
            return View();
        }
        public string VideoGetLink()
        {
            object result = new
            {
                status = true,
                source = "https://www.youtube.com/embed/m303WqGQPAM"
            };
            return JsonConvert.SerializeObject(result);
        }

    }
}