using System;
using Model.Base;

namespace Model.NHibernateEventListener
{
    public class User : ModelBase, IDateInfo
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime ModificationDate { get; set; }

        public virtual DateTime CreationDate { get; set; }
    }
}