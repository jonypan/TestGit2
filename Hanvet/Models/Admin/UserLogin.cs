using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hanvet.Models.Admin
{
    public class UserLogin
    {
        public string username { set; get; }
        public string password { set; get; }
        public bool remember { set; get; }
        
    }
}