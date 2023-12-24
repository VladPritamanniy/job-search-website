using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.Session;
using JobHub.Web.Helpers;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class UsersQuery
        {
            public static DBUsers FindPasswordCredential(DBUsers model)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var sql = "SELECT * FROM Users WHERE Email = :email";
                    var query = session.CreateSQLQuery(sql)
                        .AddEntity(typeof(DBUsers))
                        .SetString("email", model.Email)
                        .List();

                    if (query.Count == 1)
                    {
                        var dbUser = query[0] as DBUsers;
                        string hashedPassword = PasswordHasher.HashPassword(model.Password, dbUser.Salt);

                        if (hashedPassword == dbUser.Password)
                        {
                            return dbUser;
                        }
                    }

                    return null;
                }
            }

            public static void WritePasswordCredential(DBUsers model)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            string salt = PasswordHasher.GenerateSalt();
                            string hashedPassword = PasswordHasher.HashPassword(model.Password, salt);

                            var sql = $"INSERT INTO Users (Name, Password, Salt, Email) VALUES (:name, :password, :salt, :email)";
                            var query = session.CreateSQLQuery(sql)
                                .SetString("name", model.Name)
                                .SetString("password", hashedPassword)
                                .SetString("salt", salt)
                                .SetString("email", model.Email);

                            query.ExecuteUpdate();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
