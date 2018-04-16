using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using PagedList;
using Hanvet.Areas.Admin.Code;

namespace Hanvet.Areas.Admin.Controllers
{
    public class TintucController : BaseController<ArticleDetail>
    {

        public TintucController() : base("tintuc")
        {

        }
        // GET: Admin/Tintuc
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (SessionHelper.getLanguageSession() == "en")
                return Tintucen(page,pageSize);
            else
                return Tintucvn(page, pageSize);
        }
        public ActionResult Tintucvn(int page = 1, int pageSize = 10)
        {
            SessionHelper.setLanguageSession("vi");
            int totalPage = 0;
            var listArticle = AbstractDAOFactory.Instance().CreateArticleDao().Article_CMS_List(SessionHelper.getLanguageSession(), 1, 1000, out totalPage);
            return View(listArticle.ToPagedList(page, pageSize));
        }
        public ActionResult Tintucen(int page = 1, int pageSize = 10)
        {
            SessionHelper.setLanguageSession("en");
            int totalPage = 0;
            var listArticle = AbstractDAOFactory.Instance().CreateArticleDao().Article_CMS_List(SessionHelper.getLanguageSession(), 1, 1000, out totalPage);
            return View(listArticle.ToPagedList(page, pageSize));
        }
        // POST: Admin/Category/Delete/5

        public override ActionResult DeleteRewrite(ArticleDetail article)
        {
            try
            {
                article.PublicTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (AbstractDAOFactory.Instance().CreateArticleDao().Article_Edit(3, SessionHelper.getAdminSession().userID, article) > 0) //category.Name,category.MetaTitle,(category.ParentID == null ? 0 : (int)category.ParentID.Value
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi hệ thống!");
                        return RedirectToAction("Index");
                    }

                }
                ModelState.AddModelError("", "Có lỗi!");
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            var listCate = AbstractDAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
            ViewBag.listCate = listCate;
            return View();
        }
        public override ActionResult CreateRewrite(ArticleDetail article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    article.Status = 1;
                    if (AbstractDAOFactory.Instance().CreateArticleDao().Article_Edit(1,SessionHelper.getAdminSession().userID,article) > 0) //category.Name,category.MetaTitle,(category.ParentID == null ? 0 : (int)category.ParentID.Value
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi hệ thống!");
                        return View(article);
                    }

                }
                ModelState.AddModelError("", "Có lỗi!");
                return View(article);
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            ArticleDetail article = AbstractDAOFactory.Instance().CreateArticleDao().GetArticleDetail(id);
            var listCate = AbstractDAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
            ViewBag.listCate = listCate;
            return View(article);
        }

        // POST: Admin/Category/Edit/5

        public override ActionResult EditRewrite(ArticleDetail article)
        {
            try
            {
                var listCate = AbstractDAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
                ViewBag.listCate = listCate;
                if (ModelState.IsValid)
                {
                    if (AbstractDAOFactory.Instance().CreateArticleDao().Article_Edit(2, SessionHelper.getAdminSession().userID, article) > 0) //category.Name,category.MetaTitle,(category.ParentID == null ? 0 : (int)category.ParentID.Value
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi hệ thống!");
                        return View(article);
                    }

                }
                ModelState.AddModelError("", "Có lỗi!");
                return View(article);
            }
            catch
            {
                return View();
            }
        }

    }
}