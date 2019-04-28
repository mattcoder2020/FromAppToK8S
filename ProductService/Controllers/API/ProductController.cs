using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Common.Dispacher;
using Common.Dispatcher;
using Common.Metrics;
using Common.RabbitMQ;
using Common.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using ProductService.Commands;
//using ProductService.Metrics;
//using ProductService.Models;

namespace ProductService.Controllers.API
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        IComponentContext _componentContext;
        IDispatcher _dispatcher;
        public ProductController(IComponentContext componentContext, IDispatcher dispatcher, IBusPublisher busPublisher, ITracer tracer ) : base (busPublisher, tracer)
        {
            _componentContext = componentContext;
            _dispatcher = dispatcher;
            
        }
        // POST: api/Product
        [HttpPost]
        [AppMetricCount(MetricName: "post-new-product")]
        public async void Post([FromBody] NewProductCommand value)
        {
            //IDispatcher dispatch = _componentContext.Resolve<ICommandDispatcher>();
            //dispatch.Dispatch<NewProductCommand>();
            value.Context = GetContext<NewProductCommand>(null, null);
            await _dispatcher.SendAsync<NewProductCommand>(value);
            // await base.SendAsync<NewProductCommand>(value);
        }
              

    }
}
