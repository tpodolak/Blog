using System.Collections.Generic;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Model.Base;

namespace Model.NHibernateAutomappings
{
    public class Project : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Task> Tasks { get; set; }
        public virtual string SomeIgnoredProperty { get; set; }
    }

    public class ProjectMapping : IAutoMappingOverride<Project>
    {
        public void Override(AutoMapping<Project> mapping)
        {
            mapping.IgnoreProperty(val => val.SomeIgnoredProperty);
        }
    }
}
