using Extend.DataAccess.DAO;
using Extend.DataAccess.DAOImpl;

namespace Extend.DataAccess
{
    public class ADODAOFactory : AbstractDAOFactory
    {
        public override IAccountDAO CreateAccountDao()
        {
            return new AccountDAOlmpl();
        }

        public override IArticle CreateArticleDao()
        {
            return new ArticleDAOImpl();
        }

        public override ICommon CreateCommonDao()
        {
            return new CommonDAOImpl();
        }

        public override IProduct CreateProductDao()
        {
            return new ProductDAOImpl();
        }
    }
}