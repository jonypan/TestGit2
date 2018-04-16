using Extend.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAO
{
    public interface ICommon
    {
        List<Category> GetCate(string siteName);
        List<Menu> GetMenuByUserID(int userID);
        List<Function> GetAllFunction();
    }
}
