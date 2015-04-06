using System;
using FluentNHibernate.Automapping;
using Model.Base;

namespace NHibernateDisjunction
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof (ModelBase));
        }
    }
}
