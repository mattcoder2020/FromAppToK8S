using Common.Messages;
using System;

namespace OrderService.Events
{
    [MessageNamespace("matt-product")]
    public class ProductCreated : IEvent
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
