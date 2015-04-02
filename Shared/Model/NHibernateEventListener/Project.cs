using System;
using System.Collections.Generic;
using Model.Base;

namespace Model.NHibernateEventListener
{
    public class Project : ModelBase, IDateInfo
    {
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Task> Tasks { get; set; }
        public virtual string SomeIgnoredProperty { get; set; }
        public virtual DateTime ModificationDate { get; set; }

        public virtual DateTime CreationDate { get; set; }
    }
}