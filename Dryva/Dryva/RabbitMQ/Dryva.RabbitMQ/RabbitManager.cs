using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dryva.RabbitMQ
{
    public class RabbitManager : IRabbitManager
    {
        private readonly DefaultObjectPool<IModel> _objectPool;

        public RabbitManager(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);

           
        }

        public void Subscribe<T>(string queueName, string routeKey, Action<T> action) 
        {
            var channel = _objectPool.Get();
            try
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (s, e) =>
                {
                    if (e.RoutingKey == routeKey && action != null)
                    {
                        var message = Encoding.UTF8.GetString(e.Body);
                        var result = JsonConvert.DeserializeObject<T>(message);
                        action(result);
                    }
                };

                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }


        public void Publish<T>(T message, string exchangeName, string queueName, string routeKey, Dictionary<string, object> headers)
            where T : class
        {
            if (message == null)
                return;

            var channel = _objectPool.Get();
            try
            {
                channel.ExchangeDeclare(exchangeName, "topic", true, false, null);
                channel.QueueBind(queueName, exchangeName, routeKey);
                // channel.QueueDeclare(queue: exchangeName,  durable: false, exclusive: false,  autoDelete: false,   arguments: null);

                var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                if (headers != null)
                {
                    properties.Headers = new Dictionary<string, object>();
                    foreach (var item in headers)
                    {
                        properties.Headers.Add(item.Key, item.Value);
                    }
                }

                //channel.ConfirmSelect();
                channel.BasicPublish(exchangeName, routeKey, properties, sendBytes);
                //channel.WaitForConfirmsOrDie();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }
              
    }

}
