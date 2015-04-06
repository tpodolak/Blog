namespace NHibernateAutomappings.Model
{
    public class Task : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual Project Project { get; set; }
    }
}
