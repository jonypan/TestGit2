using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Extend.DataAccess.DAO;
using Extend.Utilities;
using Extend.DataAccess.DTO;
using System.Collections.Generic;
using Extend.Utilities.IpAddress;

namespace Extend.DataAccess.DAOImpl
{
    public class AccountDAOlmpl : IAccountDAO
    {
        private DBHelper db = null;
        public AccountDAOlmpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }

        public int User_Login(string username, string password)
        {
            try
            {
                int responseStatus = 0;
                int userID = 0;
                var oCommand = new SqlCommand("[cms].[SP_User_Login]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_Username", username));
                oCommand.Parameters.Add(new SqlParameter("@_Password", password));
                oCommand.Parameters.Add(new SqlParameter("@_ClientIP", IPAddressHelper.GetClientIP()));

                var p_UserID = new SqlParameter("@_UserID", SqlDbType.Int);
                var p_ResponseStatus = new SqlParameter("@_ResponseStatus", SqlDbType.Int);
                p_UserID.Direction = ParameterDirection.Output;
                p_ResponseStatus.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_UserID);
                oCommand.Parameters.Add(p_ResponseStatus);
                db.ExecuteNonQuery(oCommand);

                userID = p_ResponseStatus.SqlValue.ToString() != "Null" ? (int)p_UserID.Value : 0;
                responseStatus = p_ResponseStatus.SqlValue.ToString() != "Null" ? (int)p_ResponseStatus.Value : 0;
                if (responseStatus > 0)
                    return userID;
                else return responseStatus;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return -69;
            }
        }
      
    }
}
