using Microsoft.Extensions.Configuration;
using NHibernate;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace JobHub.DAL.Session
{
    public sealed class NHibernateSessionManager
    {
        private readonly ISessionFactory _sessionFactory;
        private ISession _currentSession;

        #region Thread-safe, lazy Singleton

        public static NHibernateSessionManager Instance => Nested.NHibernateSessionManager;

        private NHibernateSessionManager()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var nhibernateConfig = new Configuration();
            nhibernateConfig.DataBaseIntegration(d =>
            {
                d.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                d.Dialect<MsSql2012Dialect>();
                d.Driver<MicrosoftDataSqlClientDriver>();
            });

            nhibernateConfig.AddAssembly(Assembly.GetExecutingAssembly());
            _sessionFactory = nhibernateConfig.BuildSessionFactory();
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly NHibernateSessionManager NHibernateSessionManager = new NHibernateSessionManager();
        }

        #endregion

        public ISession GetSession()
        {
            if (_currentSession == null || !_currentSession.IsOpen)
            {
                _currentSession = _sessionFactory.OpenSession();
            }

            return _currentSession;
        }
    }
}
