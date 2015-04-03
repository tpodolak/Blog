using System.Collections.Generic;

namespace NInjectInterceptors
{
    public interface IRepository<T> where T:class
    {
        [return: NotNull]
        List<T> GetAll();
        void Update([NotNull] T entity);
    }
}
