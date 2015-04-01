using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Model.NHibernateAutomappings;
using NHibernate;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;

namespace DAL
{
   public class DataAccesLayer
    {
        private static DataAccesLayer _instance;
        private static readonly object InstanceLock = new object();
        private DataAccesLayer()
        {

        }


        private ISessionFactory _sessionFactory;
        private ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = BuildFactory()); }
        }

        public static DataAccesLayer Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    return _instance ?? (_instance = new DataAccesLayer());

                }
            }
        }

        /// <summary>
        /// The build factory.
        /// </summary>
        /// <returns>
        /// The <see cref="ISessionFactory"/>.
        /// </returns>
        private ISessionFactory BuildFactory()
        {
            // return Fluently.Configure()
            // .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=TOMEKKOMPUTER;Initial Catalog=GeneralLearning;Integrated Security=True"))
            // .Mappings(val =>val.FluentMappings.AddFromAssemblyOf<Appointment>())
            // .BuildSessionFactory();

            ISessionFactory buildSessionFactory = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    @"Data Source=TOMEKKOMPUTER;Initial Catalog=GeneralLearning;Integrated Security=True").ShowSql())
                .Mappings(val => val.AutoMappings.Add(CreateAutomappings))
                .ExposeConfiguration(val =>
                {
                    val.Properties["format_sql"] = "true";
                    //uncomment if You dont want to create database based on mappings
                    new SchemaExport(val).Execute(true, true, false);
                })
                .BuildSessionFactory();

            return
                buildSessionFactory;
        }


        private AutoPersistenceModel CreateAutomappings()
        {

            return AutoMap.AssemblyOf<Project>(new DefaultAutomappingConfiguration())
                          .UseOverridesFromAssemblyOf<Project>()
                          .Conventions.Setup(val =>
                                                                           {
                                                                               val.Add<DefaultTableNameConvention>();
                                                                               val.Add<DefaultPrimaryKeyConvention>();
                                                                               val.Add<DefaultStringLengthConvention>();
                                                                               val.Add<DefaultReferenceConvention>();
                                                                               val.Add<DefaultHasManyConvention>();
                                                                           });
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
}