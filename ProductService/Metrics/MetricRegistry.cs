//using App.Metrics;
//using App.Metrics.Counter;


//namespace ProductService.Metrics
//{
//    public class MetricRegistry : IMetricRegistry
//    {
//        private readonly IMetricsRoot root;
        
//        private readonly string name;

//        public MetricRegistry(IMetricsRoot root) => this.root = root; 

//        public void IncrementCount(string name)
//        {
//            CounterOptions option = new CounterOptions { Name = "post-new-product" };
//            root.Measure.Counter.Increment(option);
//        }
//    }
//}
