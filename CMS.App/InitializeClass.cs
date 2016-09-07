using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Inf.RabbitMq;
using CMS.Model.Domain;
using NLog;
using RabbitMQ.Client;

namespace CMS.App
{
    public class InitializeClass
    {
        readonly ILogger _logger;
        readonly IModel _connector;
        readonly StatisticData _statistic;
        readonly IWikiService _service;
        RabbitBuild _rpc;

        public InitializeClass(ILogger logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Info, "Start init");
            _statistic = new StatisticData();
            _service= new WikiSarvice(logger);
            _connector = new RabbitConnector(_logger).Connect("localhost");

        }
        public void Start()
        {
            _logger.Log(LogLevel.Info, "Starting RPC");
            if(_connector==null)
                _logger.Fatal("!NOT CONNECTION WITH RABBIT!");
            else
                _rpc = new RabbitBuild(_logger, _connector, "rec_con", _service, _statistic);
            
        }
    }
}
