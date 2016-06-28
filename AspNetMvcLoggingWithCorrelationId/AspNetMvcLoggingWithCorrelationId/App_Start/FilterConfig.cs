using System.Web;
using System.Web.Mvc;
using AspNetMvcLoggingWithCorrelationId.Filters;

namespace AspNetMvcLoggingWithCorrelationId
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new GlobalExceptionHandler());
		}
	}
}
