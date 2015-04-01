using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DAL
{

    public class DefaultTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(string.Format("{0}{1}", "GL_", instance.EntityType.Name));
        }
    }

    public class DefaultPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
            instance.GeneratedBy.Native();
        }
    }

    public class DefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(50);
        }
    }

    public class DefaultReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(string.Format(instance.Class.Name.StartsWith("Id") ? "{1}" : "{0}{1}", "Id",
                                          instance.Class.Name));
            instance.LazyLoad();

        }
    }

    public class DefaultHasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(string.Format("{0}{1}", "Id", instance.EntityType.Name));
            instance.LazyLoad();
        }
    }
}
