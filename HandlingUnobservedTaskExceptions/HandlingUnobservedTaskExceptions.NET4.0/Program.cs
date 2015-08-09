using System;
using System.Threading.Tasks;
using HandlingUnobservedTaskExceptions.Common;

namespace HandlingUnobservedTaskExceptions.NET4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Utilities.HandleExceptionContinueWith();
            Utilities.HandleExceptionTryCatchWait();
            Utilities.HandleExceptionTryCatchResult();
            // we won't get unobserved exception in here
            Utilities.WaitForFinalizers();

            Utilities.FireAndForgetNoExceptionHandling();
            // exception is not handled in here so once GC collects the task TaskUnobservedException will be thrown
            Utilities.WaitForFinalizers();
            Console.ReadKey();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("There was unhandled exception in the code, application will terminate. Exception is: {0}", e.ExceptionObject);
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("Unobserved exception logged - process WILL BE KILLED because we are running .NET 4.0, Exception is: {0}", e.Exception);
        }
    }
}
