using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace NInjectInterceptors
{
    public static class IOCContainer
    {
        private static readonly IKernel Kernel;
        static IOCContainer()
        {
            Kernel = new StandardKernel();
        }

        public static void Configure()
        {
            Kernel.Bind(typeof(IRepository<Car>)).To(typeof(CarRepository)).Intercept().With<ValidaitionInterceptor>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
