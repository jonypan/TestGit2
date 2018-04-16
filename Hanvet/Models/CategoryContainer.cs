using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extend.DataAccess.DTO;
namespace Hanvet.Models
{
    public class CategoryContainer
    {
        public List<Category> cateList { set; get; }
        public List<Category> getCateByParent(int parent)
        {
            var list = cateList.FindAll(x => x.ParentID == parent);
            return list;
        }
        public Category getCateByUrl(string url)
        {
            Category list = cateList.Find(x => x.Url == url);
            if (list == null)
                return new Category() { CateId = -1 };
            else
                return list;
        }
    }
}