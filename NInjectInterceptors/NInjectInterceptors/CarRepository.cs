using System;
using System.Collections.Generic;

namespace NInjectInterceptors
{
    public class CarRepository : IRepository<Car>
    {
    
        public List<Car> GetAll()
        {
            return null;
        }

        public  void Update(Car entity)
        {
            
        }
    }

    public static class ValidationHelper
    {
        public static void CheckNotNull(object entity, string argumentName)
        {
            if (entity == null)
                throw new ArgumentNullException(argumentName);
        }
    }
}
