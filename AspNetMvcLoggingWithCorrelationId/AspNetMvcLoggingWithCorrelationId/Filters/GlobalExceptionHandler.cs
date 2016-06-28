using System;
using System.Web.Mvc;
using NLog;

namespace AspNetMvcLoggingWithCorrelationId.Filters
{
	public class GlobalExceptionHandler : FilterAttribute, IExceptionFilter
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public void OnException(ExceptionContext filterContext)
		{
			Logger.Error(filterContext.Exception);
		}
	}
}