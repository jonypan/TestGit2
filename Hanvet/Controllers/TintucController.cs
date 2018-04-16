using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DAO;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using PagedList;
using Hanvet.Code;
using Hanvet.Models;

namespace Hanvet.Controllers
{
    public class TintucController : Controller
    {
        // GET: Tintuc
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(2, 1, 100, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;

            return View(listArticleByOrder.ToPagedList(page, pageSize));
        }

        public ActionResult Tintucvn(int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(2, 1, 100, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;

            return View(listArticleByOrder.ToPagedList(page, pageSize));
        }
        public ActionResult Tintucen(int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(22222, 1, 100, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;

            return View(listArticleByOrder.ToPagedList(page, pageSize));
        }
        public ActionResult BenhVaDieuTri(string Url = "",int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            string url = Url;
            Category cate = SessionHelper.getCateSession().getCateByUrl(url);
            if (cate == null)
                cate.CateId = -1;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);
            List<Article> listArticleByOrder = dbArticle.GetListArticleByCate(cate.CateId, 1, 100, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;

            return View(listArticleByOrder.ToPagedList(page, pageSize));
        }
        public ActionResult Detail(int id)
        {
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);

            ArticleDetail article = dbArticle.GetArticleDetail(id);
            
            List<Article> listArticleByTag = dbArticle.GetArticleByTag(article.Tags,1, 6, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;
            ViewBag.listArticleByTag = listArticleByTag;

            return PartialView(article);
        }
        public ActionResult Chitiet(int id)
        {
            int totalPage = 0;
            IArticle dbArticle = ADODAOFactory.Instance().CreateArticleDao();
            List<Article> listNewArticle = dbArticle.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbArticle.GetListArticleMostView(1, 4, out totalPage);

            ArticleDetail article = dbArticle.GetArticleDetail(id);

            List<Article> listArticleByTag = dbArticle.GetArticleByTag(article.Tags, 1, 6, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;
            ViewBag.listArticleByTag = listArticleByTag;

            return PartialView(article);
        }
    }
}