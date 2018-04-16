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
    public class ArticleDAOImpl : IArticle
    {
        private DBHelper db = null;
        public ArticleDAOImpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }
        public List<Article> GetListArticleByCate(int cateID,int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_ByCate]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_CateID", cateID));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetListArticleByOrder(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_ByOrder]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetListArticleNew(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_New]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetListArticleMostView(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_MostView]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetArticleByTag(string TagName, int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_ByTag]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_TagName", TagName));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public ArticleDetail GetArticleDetail(int id)
        {
            List<ArticleDetail> results;
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_Detail]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ArticleID", id));
                oCommand.Parameters.Add(new SqlParameter("@_View", 1));

                results = db.GetList<ArticleDetail>(oCommand);
                if (results.Count > 0)
                    return results[0];
                return new ArticleDetail();
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return new ArticleDetail();
            }
        }
        public List<ArticleDetail> Article_CMS_List(string SiteName, int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<ArticleDetail> results;
                var oCommand = new SqlCommand("[cms].[SP_Article_Get_List]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_SiteName", SiteName));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<ArticleDetail>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public long Article_Edit(int ExeType,int ExeUserID,ArticleDetail article)
        {
            
            try
            {
                var oCommand = new SqlCommand("[cms].[SP_Article_Edit]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ExeType", ExeType));
                oCommand.Parameters.Add(new SqlParameter("@_ExeUserID", ExeUserID));
                oCommand.Parameters.Add(new SqlParameter("@_ArticleID", article.ArticleId));
                oCommand.Parameters.Add(new SqlParameter("@_Title", article.Title));
                oCommand.Parameters.Add(new SqlParameter("@_Status", article.Status));
                oCommand.Parameters.Add(new SqlParameter("@_Summary", article.Summary));
                oCommand.Parameters.Add(new SqlParameter("@_Banner1", article.Banner1));
                oCommand.Parameters.Add(new SqlParameter("@_Content", article.Content));
                oCommand.Parameters.Add(new SqlParameter("@_ArticleLink", article.ArticleLink));
                oCommand.Parameters.Add(new SqlParameter("@_MainCateId", article.Main_CateId));
                oCommand.Parameters.Add(new SqlParameter("@_Tags", article.Tags));
                oCommand.Parameters.Add(new SqlParameter("@_PublicTime", article.PublicTime));
                oCommand.Parameters.Add(new SqlParameter("@_OrderID", article.OrderID));

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
    }
}
