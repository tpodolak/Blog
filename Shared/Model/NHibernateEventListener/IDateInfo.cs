using System;

namespace Model.NHibernateEventListener
{
    public interface IDateInfo
    {
        DateTime ModificationDate { get; set; }
        DateTime CreationDate { get; set; }
    }
}