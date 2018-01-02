using System;
using System.Collections.Generic;
using AspNetCoreManuallyRetrieveSwaggerSchema.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreManuallyRetrieveSwaggerSchema.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), 200)]
        public IActionResult Get()
        {
            var orders = new[]
            {
                new Order {Id = 1, Customer = "John Doe"},
                new Order {Id = 2, Customer = "Bob Smith"},
                new Order {Id = 3, Customer = "Jane Doe", EffectiveDate = DateTimeOffset.UtcNow.AddDays(7d)}
            };

            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id) => Ok(new Order {Id = id, Customer = "John Doe"});

        [HttpPost]
        [ProducesResponseType(typeof(Order), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            order.Id = 42;

            return CreatedAtRoute(new {id = order.Id}, order);
        }
    }
}