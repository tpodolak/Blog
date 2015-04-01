using Model.Base;

namespace Model.NHibernateAutomappings
{
    public class Task : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual Project Project { get; set; }
    }
}
