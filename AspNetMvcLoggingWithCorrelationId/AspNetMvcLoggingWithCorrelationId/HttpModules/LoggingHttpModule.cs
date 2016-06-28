using System;
using System.Web;
using NLog;

namespace AspNetMvcLoggingWithCorrelationId.HttpModules
{
	public class LoggingHttpModule : IHttpModule
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public void Init(HttpApplication context)
		{
			context.BeginRequest += HandleBeginRequest;
			context.EndRequest += HandleEndRequest;
		}

		public void Dispose()
		{
		}

		private void HandleBeginRequest(object sender, EventArgs e)
		{
			MappedDiagnosticsLogicalContext.Set("correlationid", Guid.NewGuid().ToString());
			var httpApplication = (HttpApplication)sender;
			var httpContext = httpApplication.Context;

			Logger.Info($"Abount to start {httpContext.Request.HttpMethod} {httpContext.Request.RawUrl} request");
		}

		private void HandleEndRequest(object sender, EventArgs e)
		{
			var httpApplication = (HttpApplication)sender;
			var httpContext = httpApplication.Context;

			Logger.Info($"Request completed with status code: {httpContext.Response.StatusCode} ");
		}
	}
}