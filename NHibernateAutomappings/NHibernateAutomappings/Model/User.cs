namespace NHibernateAutomappings.Model
{
    public class User : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
    }
}
