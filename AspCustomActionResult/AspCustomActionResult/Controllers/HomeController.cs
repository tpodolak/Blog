using System.IO;
using System.Web.Mvc;
using AspCustomActionResult.ActionResults;
using AspCustomActionResult.Reports;

namespace AspCustomActionResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public void ExportToPdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var testReport = new TestReport();
                testReport.CreateDocument();
                testReport.ExportToPdf(stream);
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(stream.ToArray());
            }
        }

        public PDFActionResult ExportToPdfUsingCustomResult()
        {
            var testReport = new TestReport();
            return new PDFActionResult(testReport);
        }
    }
}
