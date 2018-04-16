using Extend.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAO
{
    public interface IProduct
    {
        List<Product> GetListProductByOrder(int cateID, int pageNum, int pageSize, out int totalPage);
        List<Product> GetListProductByCate(int cateID,int pageNum, int pageSize, out int totalPage);
        
        ProductDetail GetProductDetail(int id);

        long Product_Edit(int ExeType, int ExeUserID, ProductDetail product);
        List<ProductDetail> GetCMSListProduct(string SiteName, int pageNum, int pageSize, out int totalPage);
    }
}
