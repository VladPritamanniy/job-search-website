using JobHub.DAL.DBObjects;
using JobHub.DAL.DataQueries;

namespace JobHub.BLL.WrapperQuery
{
    public partial class WrapperQuery
    {
        public static class WrapperAuth
        {
            public static bool FindPasswordCredential(DBUsers model)
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
