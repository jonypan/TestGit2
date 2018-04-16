using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hanvet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Điều hướng trang tiếng việt
            routes.MapRoute(
                name: "trang-chu",
                url: "trang-chu",
                defaults: new { controller = "Trangchu", action = "TrangchuVn", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );

            
            routes.MapRoute(
                name: "tin-tuc",
                url: "tin-tuc",
                defaults: new { controller = "Tintuc", action = "Tintucvn", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "tin-tuc-chi-tiet",
                url: "tin-tuc/chi-tiet/{id}",
                defaults: new { controller = "Tintuc", action = "chitiet", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "benh-va-dieu-tri",
                url: "benh-va-dieu-tri/{url}",
                defaults: new { controller = "Tintuc", action = "BenhVaDieuTri", url = "benh-va-dieu-tri" },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "san-pham",
                url: "san-pham/{url}",
                defaults: new { controller = "Sanpham", action = "Sanphamvn", url = "san-pham" },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "san-pham-chi-tiet",
                url: "san-pham/chi-tiet/{id}",
                defaults: new { controller = "Sanpham", action = "chitiet", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            // Điều hướng trang tiếng anh
            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Trangchu", action = "TrangchuEn", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );

            routes.MapRoute(
               name: "news",
               url: "news",
               defaults: new { controller = "Tintuc", action = "Tintucen", id = UrlParameter.Optional },
               namespaces: new[] { "Hanvet.Controllers" }
           );
            routes.MapRoute(
               name: "news-detail",
               url: "news/detail/{id}",
               defaults: new { controller = "Tintuc", action = "detail", id = UrlParameter.Optional },
               namespaces: new[] { "Hanvet.Controllers" }
           );
            routes.MapRoute(
                name: "products",
                url: "products/{url}",
                defaults: new { controller = "Sanpham", action = "sanphamen", url = "products" },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "products-detail",
                url: "products/detail/{id}",
                defaults: new { controller = "Sanpham", action = "detail", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
        }
    }
}
