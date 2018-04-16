using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DTO
{
    public class Category
    {
        public int CateId { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconPath { get; set; }
        public string Url { get; set; }
        public string RewriteUrl { get; set; }
        public string SiteName { get; set; }
        public int Type { get; set; }
        public string RwURL
        {
            get
            {
                return RewriteUrl;
            }
        }
    }
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Banner1 { get; set; }
        public string Banner2 { get; set; }
        public string Banner3 { get; set; }
        public string Banner4 { get; set; }
        public string CateName { get; set; }
        public string CateLink { get; set; }
        public string ArticleLink { get; set; }
        public DateTime PublicTime { get; set; }
        public int ViewCount { get; set; }
        public string Author { get; set; }
        public string Sitename { get; set; }
        public string RwURL
        {
            get
            {
                if (Sitename == "vi") return "/tin-tuc/chi-tiet/" + ArticleId;
                else return "/news/detail/" + ArticleId;
            }
        }
    }
    public class ArticleDetail
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Banner1 { get; set; }
        public string Banner2 { get; set; }
        public string Banner3 { get; set; }
        public string Banner4 { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Cates { get; set; }
        public string CateName { get; set; }
        public string CateLink { get; set; }
        public string ArticleLink { get; set; }
        public int Main_CateId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublicTime { get; set; }
        public int ViewCount { get; set; }
        public int Status { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Image { get; set; }
        public int TinHot { get; set; }
        public int ReferenceID { get; set; }
        public int OrderID { get; set; }
        public string Sitename { get; set; }
        public string RwURL
        {
            get
            {
                if (Sitename == "vi") return "/tin-tuc/chi-tiet/" + ArticleId;
                else return "/news/detail/" + ArticleId;
            }
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string ProductLink { get; set; }
        public string CateName { get; set; }
        public string CateLink { get; set; }
        public DateTime PublicTime { get; set; }
        public int ViewCount { get; set; }
        public int OrderID { get; set; }
        public string Sitename { get; set; }
        public string RwURL
        {
            get
            {
                if (Sitename == "vi") return "/san-pham/chi-tiet/" + ProductID;
                else return "/products/detail/" + ProductID;
            }
        }
    }
    public class ProductDetail
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Cates { get; set; }
        public int MainCateID { get; set; }
        public string Image { get; set; }
        public string ProductLink { get; set; }
        public string CateName { get; set; }
        public string CateLink { get; set; }
        public DateTime PublicTime { get; set; }
        public int ViewCount { get; set; }
        public int OrderID { get; set; }
        public string Sitename { get; set; }
        public string RwURL
        {
            get
            {
                if (Sitename == "vi") return "/san-pham/chi-tiet/" + ProductID;
                else return "/products/detail/" + ProductID;
            }
        }
    }
    public class Menu
    {
        public int FunctionID { set; get; }
        public string FunctionName { set; get; }
        public string Url { set; get; }
        public string Code { set; get; }
        public bool IsInsert { set; get; }
        public bool IsUpdate { set; get; }
        public bool IsDelete { set; get; }
        public int FatherID { set; get; }
        public int OrderID { set; get; }
        public string RwURL
        {
            get
            {
                return "/admin/" + Url;
            }
        }
    }
    public class Function
    {
        public int FunctionID { get; set; }

        public string FunctionName { get; set; }

        public string Url { get; set; }

        public bool? IsDisplay { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int? FatherID { get; set; }

        public int? Order { get; set; }
    }
}
