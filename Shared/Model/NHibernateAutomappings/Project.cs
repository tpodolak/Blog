using System.Collections.Generic;
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
}
