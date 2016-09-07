using System;
using NLog;
using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    public class RabbitConnector
    {

        private IModel Channel { get; set;}
        private readonly ILogger _logger;
        public RabbitConnector(ILogger logger)
        {
            _logger = logger;

        }

        public IModel Connect(string host)
        {
            _logger.Info("Connecting to rabbit server");
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = host
                };
                var connection = factory.CreateConnection();
                Channel = connection.CreateModel();
            }
            catch (Exception)
            {
                _logger.Error("Bad connection (rabbit)");
                return null;
            }

            _logger.Info("Connected to rabbit");

            return Channel;
        }

        public void Disconnect()
        {
            Channel.Close();
            _logger.Info("Disconnected (rabbit)");
        }
        
    }
}
