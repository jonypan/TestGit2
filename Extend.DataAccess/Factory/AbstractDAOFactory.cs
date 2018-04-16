using System;
using Extend.DataAccess.DAO;

namespace Extend.DataAccess
{
    public abstract class AbstractDAOFactory
    {
        public static AbstractDAOFactory Instance()
        {
            try
            {
                return (AbstractDAOFactory)new ADODAOFactory();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't create AbstractDAOFactory: ");
            }
        }

        public abstract IAccountDAO CreateAccountDao();
        public abstract IArticle CreateArticleDao();
        public abstract ICommon CreateCommonDao();
        public abstract IProduct CreateProductDao();
    }
}