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
    public class ProductDAOImpl : IProduct
    {
        private DBHelper db = null;
        public ProductDAOImpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }

        public List<Product> GetListProductByOrder(int cateID, int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Product> results;
                var oCommand = new SqlCommand("[dbo].[SP_Product_Get_List_ByOrder]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_CateID", cateID));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Product>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Product> GetListProductByCate(int cateID,int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Product> results;
                var oCommand = new SqlCommand("[dbo].[SP_Product_Get_List_ByOrder]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_CateID", cateID));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Product>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<ProductDetail> GetCMSListProduct(string SiteName, int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<ProductDetail> results;
                var oCommand = new SqlCommand("[cms].[SP_Product_Get_List]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_SiteName", SiteName));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<ProductDetail>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public long Product_Edit(int ExeType, int ExeUserID, ProductDetail product)
        {

            try
            {
                var oCommand = new SqlCommand("[cms].[SP_Product_Edit]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ExeType", ExeType));
                oCommand.Parameters.Add(new SqlParameter("@_ExeUserID", ExeUserID));
                oCommand.Parameters.Add(new SqlParameter("@_ProductID", product.ProductID));
                oCommand.Parameters.Add(new SqlParameter("@_Title", product.Title));
                oCommand.Parameters.Add(new SqlParameter("@_Summary", product.Summary));
                oCommand.Parameters.Add(new SqlParameter("@_Image", product.Image));
                oCommand.Parameters.Add(new SqlParameter("@_Content", product.Content));
                oCommand.Parameters.Add(new SqlParameter("@_ProductLink", product.ProductLink));
                oCommand.Parameters.Add(new SqlParameter("@_MainCateId", product.MainCateID));
                oCommand.Parameters.Add(new SqlParameter("@_PublicTime", product.PublicTime));
                oCommand.Parameters.Add(new SqlParameter("@_OrderID", product.OrderID));

                var p_ResponseStatus = new SqlParameter("@_ResponseStatus", SqlDbType.BigInt);
                p_ResponseStatus.Direction = ParameterDirection.Output;
                oCommand.Parameters.Add(p_ResponseStatus);

                db.ExecuteNonQuery(oCommand);

                return p_ResponseStatus.SqlValue.ToString() != "Null" ? (long)p_ResponseStatus.Value : 0;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return -69;
            }
        }
        public ProductDetail GetProductDetail(int id)
        {
            List<ProductDetail> results;
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Product_Get_Detail]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ProductID", id));
                oCommand.Parameters.Add(new SqlParameter("@_View", 1));

                results = db.GetList<ProductDetail>(oCommand);
                if (results.Count > 0)
                    return results[0];
                return new ProductDetail();
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return new ProductDetail();
            }
        }
    }
}
