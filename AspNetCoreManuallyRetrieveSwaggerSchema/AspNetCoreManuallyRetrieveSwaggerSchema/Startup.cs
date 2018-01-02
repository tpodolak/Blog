using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreManuallyRetrieveSwaggerSchema
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(
                options =>
                {
                    options.CustomSchemaIds(type => type.FullName);
                    options.DescribeAllEnumsAsStrings();
                    options.SwaggerDoc("Sample API", new Info
                    {
                        Title = $"Sample API",
                        Version = "1",
                        Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
                        Contact = new Contact {Name = "Bill Mei", Email = "bill.mei@somewhere.com"},
                        TermsOfService = "Shareware",
                        License = new License {Name = "MIT", Url = "https://opensource.org/licenses/MIT"}
                    });
                });
        }

        /// <summary>
        /// Configures the application using the provided builder, hosting environment, and logging factory.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current hosting environment.</param>
        /// <param name="loggerFactory">The logging factory used for instrumentation.</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/Sample API/swagger.json", "swagger"));
        }
    }
}