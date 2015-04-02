using JetBrains.Annotations;

namespace ResharperAnnotations
{
    public  class Repository<T> : IRepository<T> where T : class
    {
        public virtual T FindOne(int id)
        {
            return null;
        }
    }
}