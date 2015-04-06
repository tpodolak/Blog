using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Model.NHibernateEventListener;

namespace NHibernateEventListener.Mappings
{
    public class ProjectMapping : IAutoMappingOverride<Project>
    {
        public void Override(AutoMapping<Project> mapping)
        {
            mapping.IgnoreProperty(val => val.SomeIgnoredProperty);
        }
    }
}