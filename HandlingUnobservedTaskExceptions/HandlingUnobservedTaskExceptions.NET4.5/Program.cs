using System;
using System.Threading.Tasks;
using HandlingUnobservedTaskExceptions.Common;

namespace HandlingUnobservedTaskExceptions.NET4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Utilities.HandleExceptionContinueWith();
            Utilities.HandleExceptionContinueWithAndHandleMethod();
            Utilities.HandleExceptionTryCatchWait();
            Utilities.HandleExceptionTryCatchResult();
            HandleExceptionTryCatchAwait();

            // we won't get unobserved exception in here
            Utilities.WaitForFinalizers();

            Utilities.FireAndForgetNoExceptionHandling();
            // exception is not handled in here so once GC collects the task TaskUnobservedException will be thrown
            Utilities.WaitForFinalizers();
            Console.ReadKey();
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("Unobserved exception logged - process will not be killed because we are running .NET 4.5 (unless you changed escalation policy). Exception is: {0}", e.Exception);
        }

        // called from Main
        public static async void HandleExceptionTryCatchAwait()
        {
            // Console.WriteLine("Calling HandleExceptionTryCatchAwait");
            try
            {
                await HandleExceptionTryCatchAwaitInternal();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HandleExceptionTryCatchAwait: exception handled in try catch block");
            }
        }


        static async Task<int> HandleExceptionTryCatchAwaitInternal()
        {
            return await Task.Factory.StartNew(() =>
            {
                throw new Exception();
                return 1;
            }, TaskCreationOptions.LongRunning);
        }
    }
}
