using AspNetCoreCustomLoggerAndNLogCallsiteIssue.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;

namespace AspNetCoreCustomLoggerAndNLogCallsiteIssue
{
    public class Startup
    {
        private readonly IOptions<AppSettingsOptions> _appSettingsOptions;

        public Startup(IConfiguration configuration, IHostingEnvironment env, IOptions<AppSettingsOptions> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
            Configuration = configuration;
            env.ConfigureNLog("nlog.config");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            if (_appSettingsOptions.Value.UseSameAssemblyLogger)
            {
                services.Replace(new ServiceDescriptor(typeof(ILogger<>), typeof(SameAssemblyLogger<>), ServiceLifetime.Singleton));
            }

            if (_appSettingsOptions.Value.UseSeparateAssemblyLogger)
            {
                services.Replace(new ServiceDescriptor(typeof(ILogger<>), typeof(SeparateAssemblyLogger<>), ServiceLifetime.Singleton));
                LogManager.AddHiddenAssembly(typeof(SeparateAssemblyLogger<>).Assembly);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}