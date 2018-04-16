using Extend.DataAccess;
using Extend.DataAccess.DTO;
using Hanvet.Areas.Admin.Code;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hanvet.Areas.Admin.Controllers
{
    public class SanphamController : BaseController<ProductDetail>
    {
        public SanphamController() : base("sanpham")
        {

        }
        // GET: Admin/Tintuc
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (SessionHelper.getLanguageSession() == "en")
                return Sanphamen(page, pageSize);
            else
                return Sanphamvn(page, pageSize);
        }
        public ActionResult Sanphamvn(int page = 1, int pageSize = 10)
        {
            SessionHelper.setLanguageSession("vi");
            int totalPage = 0;
            var listArticle = AbstractDAOFactory.Instance().CreateProductDao().GetCMSListProduct(SessionHelper.getLanguageSession(), 1, 1000, out totalPage);
            return View(listArticle.ToPagedList(page, pageSize));
        }
        public ActionResult Sanphamen(int page = 1, int pageSize = 10)
        {
            SessionHelper.setLanguageSession("en");
            int totalPage = 0;
            var listArticle = AbstractDAOFactory.Instance().CreateProductDao().GetCMSListProduct(SessionHelper.getLanguageSession(), 1, 1000, out totalPage);
            return View(listArticle.ToPagedList(page, pageSize));
        }
        public override ActionResult DeleteRewrite(ProductDetail product)
        {
            try
            {
                product.PublicTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (AbstractDAOFactory.Instance().CreateProductDao().Product_Edit(3, SessionHelper.getAdminSession().userID, product) > 0) //category.Name,category.MetaTitle,(category.ParentID == null ? 0 : (int)category.ParentID.Value
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
        public override ActionResult CreateRewrite(ProductDetail product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AbstractDAOFactory.Instance().CreateProductDao().Product_Edit(1, SessionHelper.getAdminSession().userID, product) > 0) //category.Name,category.MetaTitle,(category.ParentID == null ? 0 : (int)category.ParentID.Value
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi hệ thống!");
                        return View(product);
                    }

                }
                ModelState.AddModelError("", "Có lỗi!");
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            ProductDetail product = AbstractDAOFactory.Instance().CreateProductDao().GetProductDetail(id);
            var listCate = AbstractDAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
            ViewBag.listCate = listCate;
            return View(product);
        }

        // POST: Admin/Category/Edit/5

        public override ActionResult EditRewrite(ProductDetail product)
        {
            try
            {
                var listCate = AbstractDAOFactory.Instance().CreateCommonDao().GetCate(SessionHelper.getLanguageSession());
                ViewBag.listCate = listCate;
                if (ModelState.IsValid)
                {
                    if (AbstractDAOFactory.Instance().CreateProductDao().Product_Edit(2, SessionHelper.getAdminSession().userID, product) > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi hệ thống!");
                        return View(product);
                    }

                }
                ModelState.AddModelError("", "Có lỗi!");
                return View(product);
            }
            catch
            {
                return View();
            }
        }

    }
}