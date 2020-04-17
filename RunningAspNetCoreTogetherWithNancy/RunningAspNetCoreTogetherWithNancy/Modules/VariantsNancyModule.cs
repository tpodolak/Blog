using System;
using System.Collections.Generic;
using Nancy;
using RunningAspNetCoreTogetherWithNancy.Contracts;

namespace RunningAspNetCoreTogetherWithNancy.Modules
{
    public sealed class VariantsNancyModule : NancyModule
    {
        public VariantsNancyModule()
        {
            Get("variants", args => Response.AsJson(new List<Variant>
            {
                new Variant(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "first variant from nancy"),
                new Variant(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "second variant from nancy")
            }));
        }
    }
}