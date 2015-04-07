using System.IO;
using System.Web.Mvc;
using DevExpress.XtraReports.UI;

namespace AspCustomActionResult.ActionResults
{
    public class PDFActionResult : ActionResult
    {
        private readonly byte[] _byteArray;
        private const string ContentType = "application/pdf";
        public PDFActionResult(byte[] byteArray)
        {
            _byteArray = byteArray;
        }
        public PDFActionResult(XtraReport report)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                report.CreateDocument();
                report.ExportToPdf(stream);
                _byteArray = stream.ToArray();
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = ContentType;
            response.BinaryWrite(_byteArray);
        }
    }
}