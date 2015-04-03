using Ninject.Extensions.Interception;

namespace NInjectInterceptors
{
    public class ValidaitionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var parameters = invocation.Request.Method.GetParameters();
            for (int index = 0; index < parameters.Length; index++)
            {
                foreach (ArgumentValidationAttribute attr in parameters[index].GetCustomAttributes(typeof(ArgumentValidationAttribute), true))
                    attr.ValidateArgument(invocation.Request.Arguments[index], parameters[index].Name);
            }

            invocation.Proceed();

            foreach (ArgumentValidationAttribute attr in invocation.Request.Method.ReturnTypeCustomAttributes.GetCustomAttributes(typeof(ArgumentValidationAttribute), true))
            {
                attr.ValidateArgument(invocation.ReturnValue, "return value");
            }
        }
    }
}
