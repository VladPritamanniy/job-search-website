using JobHub.DAL.DataQueries;
using JobHub.DAL.DBObjects;

namespace JobHub.BLL.WrapperQuery
{
    public partial class WrapperQuery
    {
        public static class WrapperProduct
        {
            public static IEnumerable<DBProduct> GetProductsByName(string productName)
            {
                return DataQuery.ProductQuery.GetProductsByName(productName);
            }

        }
    }
}
