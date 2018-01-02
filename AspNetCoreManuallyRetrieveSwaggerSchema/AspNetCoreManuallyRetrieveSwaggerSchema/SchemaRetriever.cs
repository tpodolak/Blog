using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreManuallyRetrieveSwaggerSchema
{
    public class SchemaRetriever
    {
        private readonly Lazy<IWebHost> _webHostProxy = new Lazy<IWebHost>(() => Program.BuildWebHost(new string[0]));

        private IWebHost WebHost => _webHostProxy.Value;
        
        public string RetrieveSchema(string swaggerDocument)
        {
            var serviceProvider = WebHost.Services;
            var swaggerProvider = serviceProvider.GetRequiredService<ISwaggerProvider>();
            var mvcJsonOptions = serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>();
            var document = swaggerProvider.GetSwagger(swaggerDocument, null, "/");

            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = mvcJsonOptions.Value.SerializerSettings.Formatting,
                ContractResolver = new SwaggerContractResolver(mvcJsonOptions.Value.SerializerSettings)
            };

            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, document);
                return stringWriter.ToString();
            }
        }
    }
}