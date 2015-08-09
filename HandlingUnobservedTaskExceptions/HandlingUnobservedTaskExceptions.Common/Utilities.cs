using System;
using System.Threading;
using System.Threading.Tasks;

namespace HandlingUnobservedTaskExceptions.Common
{
    public class Utilities
    {
        public static void HandleExceptionContinueWith()
        {
            // Console.WriteLine("Calling HandleExceptionContinueWith");
            Task.Factory.StartNew(() => { throw new Exception("From method HandleExceptionContinueWith"); })
                        .ContinueWith(val =>
                        {
                            // we need to access val.Exception property otherwise unobserved exception will be thrown
                            // ReSharper disable once PossibleNullReferenceException
                            foreach (var ex in val.Exception.Flatten().InnerExceptions)
                            {
                                Console.WriteLine("HandleExceptionContinueWith: exception handled in ContinueWith");
                            }
                        }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public static void HandleExceptionTryCatchWait()
        {
            // Console.WriteLine("Calling HandleExceptionTryCatchWait");
            try
            {
                Task.Factory.StartNew(() => { throw new Exception("From method HandleExceptionTryCatchWait"); }).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HandleExceptionTryCatchWait: exception handled in try catch block");
            }
        }

        public static void HandleExceptionTryCatchResult()
        {
            // Console.WriteLine("Calling HandleExceptionTryCatchResult");
            try
            {
                var result = Task.Factory.StartNew(() =>
                {
                    throw new Exception("From method HandleExceptionTryCatchResult");
                    return 1;
                }).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HandleExceptionTryCatchResult: exception handled in try catch block");
            }
        }

        /// <summary>
        /// This will eventually make finalizer thread to throw UnobservedTaskException
        /// </summary>
        public static void FireAndForgetNoExceptionHandling()
        {
            Console.WriteLine("Calling FireAndForgetNoExceptionHandling");
            Task.Factory.StartNew(() => { throw new Exception("From method FireAndForgetNoExceptionHandling"); });
        }

        public static void WaitForFinalizers()
        {
            Console.WriteLine("Waiting for pending finalizers");
            using (var autoresetEvent = new AutoResetEvent(false))
            {
                autoresetEvent.WaitOne(TimeSpan.FromSeconds(5));
            }

            Console.WriteLine("GC: Collecting");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC: Collected");
        }
    }
}
