using System;
using System.Web;
using NLog;

namespace AspNetMvcLoggingWithCorrelationId.HttpModules
{
	public class LoggingHttpModule : IHttpModule
	{
		private const string CorrelationIdKey = "correlationid";

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
			var value = Guid.NewGuid().ToString();
			var httpApplication = (HttpApplication) sender;
			var httpContext = httpApplication.Context;
			MappedDiagnosticsLogicalContext.Set(CorrelationIdKey, value);

			httpContext.Items[CorrelationIdKey] = value;
			Logger.Info($"About to start {httpContext.Request.HttpMethod} {httpContext.Request.RawUrl} request");
		}

		private void HandleEndRequest(object sender, EventArgs e)
		{
			var httpApplication = (HttpApplication) sender;
			var httpContext = httpApplication.Context;

			var correlationId = httpContext.Items[CorrelationIdKey].ToString();
			MappedDiagnosticsLogicalContext.Set(CorrelationIdKey, correlationId);

			Logger.Info($"Request completed with status code: {httpContext.Response.StatusCode} ");
		}
	}
}