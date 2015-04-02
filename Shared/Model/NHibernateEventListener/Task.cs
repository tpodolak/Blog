using System;
using Model.Base;

namespace Model.NHibernateEventListener
{
    public class Task : ModelBase, IDateInfo
    {
        public virtual string Name { get; set; }
        public virtual Project Project { get; set; }
        public virtual DateTime ModificationDate { get; set; }

        public virtual DateTime CreationDate { get; set; }
    }
}