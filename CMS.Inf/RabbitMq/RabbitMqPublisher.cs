using System;
using System.Text;
using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    public class RabbitMqPublisher { 

        private readonly IModel _channel;

        public RabbitMqPublisher(IModel channel)
        {
            _channel = channel;
        }

        public void Send(string exchangeName, string routingKey, IBasicProperties replyProps, string message)
        {
            _channel.BasicPublish(exchangeName,
                                routingKey,
                                replyProps,
                                Encoding.UTF8.GetBytes(message));
        }
    }
}
