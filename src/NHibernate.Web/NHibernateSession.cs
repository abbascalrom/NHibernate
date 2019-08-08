using System.Web;
using NHibernate.Cfg;

namespace NHibernate.Web
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\NHibernate.config");
            configuration.Configure(configurationPath);
            var studentConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Student.hbm.xml");
            configuration.AddFile(studentConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}