﻿using Common.Messages;
using Common.RabbitMQ;
using System;

namespace OrderService.Events
{
    [SubscriptionNamespace("order-productcreated")]
    public class ProductCreated : IEvent
    {
        public int Id { get; set; }
        public String Name { get; set; }
       // public ICorrelationContext Context { get; set; }
    }
}
