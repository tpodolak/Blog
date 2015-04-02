using JetBrains.Annotations;

namespace ResharperAnnotations
{

    public interface IRepository<out T> where T:class 
    {
        [CanBeNull]
        T FindOne(int id);
    }
}