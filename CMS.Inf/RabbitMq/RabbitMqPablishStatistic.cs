using System.Text;
using RabbitMQ.Client;


namespace CMS.Inf.RabbitMq
{
    class RabbitMqPablishStatistic
    {
        private readonly IModel _channel;

        public RabbitMqPablishStatistic()
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void Send(string exchangeName, string routingKey,  string message)
        {
            _channel.BasicPublish(exchangeName,
                                routingKey,
                                null,
                                Encoding.UTF8.GetBytes(message));
        }

    }
}
