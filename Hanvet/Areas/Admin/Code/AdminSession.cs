using Extend.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hanvet.Areas.Admin.Code
{
    public class AdminSession
    {
        public int userID { set; get; }
        public string username { set; get; }
        public List<Menu> menu { set; get; }
        public AdminSession()
        {

        }
        public List<Menu> GetMenuByFatherID(int fatherID)
        {
            return menu.FindAll(x => x.FatherID == fatherID).OrderBy(x=>-x.OrderID).ToList();
        }
        public Menu FindMenu(string code)
        {
            return menu.FirstOrDefault(x => x.Code == code);
        }
    }
}