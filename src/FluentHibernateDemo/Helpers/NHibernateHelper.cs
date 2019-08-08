using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateDemo.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public NHibernateHelper()
        {
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
           _sessionFactory = Fluently.Configure()

         .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString)) //).ShowSql())

         .Mappings(m => m.FluentMappings
         .AddFromAssemblyOf<Program>())
         .ExposeConfiguration(cfg => new SchemaExport(cfg)
         .Create(true, true))
         .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
