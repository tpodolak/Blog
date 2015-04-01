using Model.Base;

namespace Model.NHibernateAutomappings
{
    public class User : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
    }
}
