using DAL;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Model.NHibernateEventListener;
using NHibernate;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using NHibernateEventListener;

namespace NHibernateAutomappings
{
    public class DataAccesLayer
    {
        private static DataAccesLayer _instance;

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
            get { return _instance ?? (_instance = new DataAccesLayer()); }
        }

        /// <summary>
        /// The build factory.
        /// </summary>
        /// <returns>
        /// The <see cref="ISessionFactory"/>.
        /// </returns>
        private ISessionFactory BuildFactory()
        {
            ISessionFactory buildSessionFactory = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    @"Data Source=TOMEK;Initial Catalog=BlogSamples;Integrated Security=True").ShowSql())
                .Mappings(val => val.AutoMappings.Add(AutoMap.AssemblyOf<Project>(new DefaultAutomappingConfiguration()).Conventions.Setup(con =>
                {
                    con.Add(AutoImport.Never());
                    con.Add<DefaultTableNameConvention>();
                    con.Add<DefaultPrimaryKeyConvention>();
                    con.Add<DefaultStringLengthConvention>();
                    con.Add<DefaultReferenceConvention>();
                    con.Add<DefaultHasManyConvention>();
                })))
                .ExposeConfiguration(val =>
                {
                    val.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new NHListener() });
                    val.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new NHListener() });
                    val.Properties["format_sql"] = "true";
                    //uncomment if you want to create database schema based on mappings
                    new SchemaExport(val).Execute(true, true, false);
                })
                .BuildSessionFactory();

            return
                buildSessionFactory;
        }


        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}