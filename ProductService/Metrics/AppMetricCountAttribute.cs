//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProductService.Metrics
//{
//    public class AppMetricCountAttribute : ActionFilterAttribute
//    {
//        private readonly string metricname;
       
//        public IMetricRegistry metricRegistry { get; set; }
//        public AppMetricCountAttribute(string MetricName
//            //,IMetricRegistry MetricRegistry
//            )
//        {
//            metricname = MetricName;
//            //metricRegistry = MetricRegistry;
//        }

       
//        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            // Get the request lifetime scope so you can resolve services.
//            //var requestScope = context.HttpContext.Request.GetDependencyScope();

//            //// Resolve the service you want to use.
//            //var service = requestScope.GetService(typeof(IMyService)) as IMyService;

//            //// Do the rest of the work in the filter.
//            metricRegistry = (IMetricRegistry)context.HttpContext.RequestServices.GetService(typeof(IMetricRegistry));
//            metricRegistry.IncrementCount(metricname);
//            return base.OnActionExecutionAsync(context, next);
//        }
//    }
//}
