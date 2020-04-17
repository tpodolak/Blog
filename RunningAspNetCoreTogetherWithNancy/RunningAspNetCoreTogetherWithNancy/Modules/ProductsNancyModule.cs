using System;
using System.Collections.Generic;
using Nancy;
using RunningAspNetCoreTogetherWithNancy.Contracts;

namespace RunningAspNetCoreTogetherWithNancy.Modules
{
    public sealed class ProductsNancyModule : NancyModule
    {
        public ProductsNancyModule()
        {
            Get("products", args => Response.AsJson(new List<Product>
            {
                new Product(Guid.NewGuid().ToString(), "First product from nancy"),
                new Product(Guid.NewGuid().ToString(), "Second product from nancy")
            }));
        }
    }
}