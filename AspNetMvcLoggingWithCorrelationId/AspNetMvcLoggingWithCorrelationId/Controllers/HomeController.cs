using System.Web.Mvc;
using NLog;

namespace AspNetMvcLoggingWithCorrelationId.Controllers
{
	public class HomeController : Controller
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		public ActionResult Index()
		{
			Logger.Info("Info from index");
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}