using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using log4net;

namespace WCFInstanceContextModeConcurrencyModeRevisited
{
    public class ExceptionHandlerOperationInvoker : IOperationInvoker
    {
        private readonly IOperationInvoker originalInvoker;
        private readonly string operationName;
        private readonly ILog logger;
        public ExceptionHandlerOperationInvoker(IOperationInvoker originalInvoker, DispatchOperation dispatchOperation)
        {
            this.originalInvoker = originalInvoker;
            this.operationName = dispatchOperation.Name;
            logger = LogManager.GetLogger("serviceLogger");
        }

        public object[] AllocateInputs()
        {
            return this.originalInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            logger.InfoFormat("Start command operation:{0}", this.operationName);

            object result;

            try
            {
                result = this.originalInvoker.Invoke(instance, inputs, out outputs);
            }
            catch (Exception exception)
            {
                logger.Error("Unhandled Exception: ", exception);
                outputs = new object[] { };

                throw new FaultException(new FaultReason(exception.Message));
            }

            logger.InfoFormat("End command operation:{0}", this.operationName);

            return result;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            logger.InfoFormat("Start command operation:{0} async", this.operationName);

            return this.originalInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            logger.InfoFormat("End command operation:{0} async", this.operationName);

            return this.originalInvoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous => this.originalInvoker.IsSynchronous;
    }
}
