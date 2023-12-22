using JobHub.DAL.DataQueries;
using JobHub.DAL.Data.DBObjects;

namespace JobHub.BLL.WrapperQuery
{
    public partial class WrapperQuery
    {
        public static class WrapperAuth
        {
            public static DBUsers FindPasswordCredential(DBUsers model)
            {
                return DataQuery.UsersQuery.FindPasswordCredential(model);
            }

            public static void WritePasswordCredential(DBUsers model)
            {
                DataQuery.UsersQuery.WritePasswordCredential(model);
            }

        }
    }
}
