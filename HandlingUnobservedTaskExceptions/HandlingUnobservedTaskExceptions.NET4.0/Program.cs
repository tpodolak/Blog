using System;
using System.Threading.Tasks;
using HandlingUnobservedTaskExceptions.Common;

namespace HandlingUnobservedTaskExceptions.NET4._0
{
    class Program
    {
        private static bool handleUnobserved;
        static void Main(string[] args)
        {
            bool.TryParse(args != null && args.Length > 0 ? args[0] : string.Empty, out handleUnobserved);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Utilities.HandleExceptionContinueWith();
            Utilities.HandleExceptionContinueWithAndHandleMethod();
            Utilities.HandleExceptionTryCatchWait();
            Utilities.HandleExceptionTryCatchResult();
            // we won't get unobserved exception in here
            Utilities.WaitForFinalizers();

            Utilities.FireAndForgetNoExceptionHandling();
            // exception is not handled in here so once GC collects the task and all pending finalizer finishes work TaskUnobservedException will be thrown
            Utilities.WaitForFinalizers();
            Console.ReadKey();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("There was unhandled exception in the code, application will terminate. Exception is: {0}", e.ExceptionObject);
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (handleUnobserved)
            {
                e.SetObserved();
                Console.WriteLine("Unobserved exception logged and set to observed in TaskScheduler_UnobservedTaskException, Exception is: {0}", e.Exception);
            }
            else
                Console.WriteLine("Unobserved exception logged - process WILL BE KILLED because we are running .NET 4.0, Exception is: {0}",
                    e.Exception);
        }
    }
}
