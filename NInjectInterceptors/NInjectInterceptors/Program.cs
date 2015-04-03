using System;

namespace NInjectInterceptors
{
    class Program
    {
        static void Main(string[] args)
        {
            IOCContainer.Configure();
            var carRepository = IOCContainer.Get<IRepository<Car>>();
            try
            {
                // should throw ArgumentNullException 
                carRepository.Update(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // should throw ArgumentNullException, return value is null
                carRepository.GetAll();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
