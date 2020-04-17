using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;

namespace RunningAspNetCoreTogetherWithNancy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var aspNetCorePaths = new PathString[] {"/products"};
            foreach (var path in aspNetCorePaths)
            {
                app.Map(path, appBuilder =>
                {
                    // we still want to access the resource under old url, so we need to add the branch path back to the route
                    var rewriteOptions = new RewriteOptions().AddRewrite(
                        "(?<Path>.*)",
                        $"{path}/${{Path}}",
                        skipRemainingRules: true);
                    appBuilder.UseRewriter(rewriteOptions);
                    appBuilder.UseMvc();
                });
            }

            app.Map(string.Empty, appBuilder =>
            {
                appBuilder.UseOwin(options => options.UseNancy());
            });
        }
    }
}