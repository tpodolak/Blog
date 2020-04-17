using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RunningAspNetCoreTogetherWithNancy.Contracts;

namespace RunningAspNetCoreTogetherWithNancy.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("/products")]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product(Guid.NewGuid().ToString(), "First product from asp net core"),
                new Product(Guid.NewGuid().ToString(), "Second product from asp net core")
            };
        }
    }
}