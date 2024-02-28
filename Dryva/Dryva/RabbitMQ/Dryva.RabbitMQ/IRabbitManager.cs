using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.RabbitMQ
{
    public interface IRabbitManager
    {
        void Publish<T>(T message, string exchangeName, string queueName,
            string routeKey, Dictionary<string, object> headers)
        where T : class;

        void Subscribe<T>(string queueName, string routeKey, Action<T> action);
    }
}
