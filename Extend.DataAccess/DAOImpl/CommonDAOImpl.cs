using Extend.DataAccess.DAO;
using Extend.DataAccess.DTO;
using Extend.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAOImpl
{
    public class CommonDAOImpl : ICommon
    {
        private DBHelper db = null;
        public CommonDAOImpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }

        public List<Function> GetAllFunction()
        {
            try
            {
                var oCommand = new SqlCommand("[cms].[SP_Functions_GetAll] ");
                oCommand.CommandType = CommandType.StoredProcedure;

                return db.GetList<Function>(oCommand);
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }

        public List<Category> GetCate(string siteName)
        {
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Cate_Get_List]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_SiteName", siteName));

                return db.GetList<Category>(oCommand);
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }

        public List<Menu> GetMenuByUserID(int userID)
        {
            try
            {
                List<Menu> results = new List<Menu>();
                var oCommand = new SqlCommand("[cms].[SP_Functions_GetList]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_UserID", userID));

                results = db.GetList<Menu>(oCommand);
                if (results == null)
                    return new List<Menu>();
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return new List<Menu>();
            }
        }
    }
}
