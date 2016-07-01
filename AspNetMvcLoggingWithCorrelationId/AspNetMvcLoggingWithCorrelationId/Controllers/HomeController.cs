using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;

namespace AspNetMvcLoggingWithCorrelationId.Controllers
{
	public class HomeController : Controller
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public async Task<ActionResult> Index()
		{
			await PreprocessRequest(nameof(Index));

			return View();
		}

		public async Task<ActionResult> About()
		{
			await PreprocessRequest(nameof(About));
			throw new InvalidOperationException();
			return View();
		}

		public async Task<ActionResult> Contact()
		{
			await PreprocessRequest(nameof(Contact));
			ViewBag.Message = "Your contact page.";

			return View();
		}

		private static async Task PreprocessRequest(string actionName)
		{
			Logger.Info($"Log from {actionName} action, from thread={Thread.CurrentThread.ManagedThreadId}");

			await Task.Run(() => Logger.Info($"Log from thread assigned by scheduler {Thread.CurrentThread.ManagedThreadId}"))
				.ConfigureAwait(continueOnCapturedContext: false);

			Logger.Info($"Log from continuation from thread {Thread.CurrentThread.ManagedThreadId}");

			var thread = new Thread(() => Logger.Info($"Log from explicitly created thread {Thread.CurrentThread.ManagedThreadId}"));
			thread.Start();
			thread.Join();
		}
	}
}