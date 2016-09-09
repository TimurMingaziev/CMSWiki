using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using CMS.Data;
using Newtonsoft.Json;

namespace CMSPublish
{
    class RpcClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _replyQueueName;
        private readonly QueueingBasicConsumer _consumer;

        public RpcClient()
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _replyQueueName = _channel.QueueDeclare().QueueName;
            _consumer = new QueueingBasicConsumer(_channel);
            _channel.BasicConsume(queue: _replyQueueName,
                noAck: true,
                consumer: _consumer);
        }

        public string Call(object message, string routingKey)
        {
            var corrId = Guid.NewGuid().ToString();
            var props = _channel.CreateBasicProperties();
            props.ReplyTo = _replyQueueName;
            props.CorrelationId = corrId;
            var stringMessage = JsonConvert.SerializeObject(message);
            var messageBytes = Encoding.UTF8.GetBytes(stringMessage);
            _channel.BasicPublish(exchange: "",
                routingKey: routingKey,
                basicProperties: props,
                body: messageBytes);

            while (true)
            {
                var ea = (BasicDeliverEventArgs) _consumer.Queue.Dequeue();
                if (ea.BasicProperties.CorrelationId == corrId)
                {
                    return Encoding.UTF8.GetString(ea.Body);
                }
            }
        }

        public void Close()
        {
            _connection.Close();
        }
    }

    class RPC
    {

        public static void Main()
        {
            Console.WriteLine("Started");
            var rpcClient = new RpcClient();

            #region ChangePage
            PageDto chpage = new PageDto
            {
                PageId =  1,
                NamePage = "1",
                ContentPage = "ContentChanged",
                ChangerPage = "1",
                OwnerPage = "1",
                DateChangePage = DateTime.Now,
                DateCreatePage = DateTime.Now,
                SectionId = 1
            };
            MessageRabbitClass msg0 = new MessageRabbitClass
            {
                MethodName = "UpdatePage",
                Data = chpage
            };
            var response0 = rpcClient.Call(msg0, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response0);

            #endregion

            #region page

            //// PAGE ////////
            Thread.Sleep(5000);
            PageDto page = new PageDto
            {
                NamePage = "1",
                ContentPage = "22",
                ChangerPage = "1",
                OwnerPage = "1",
                DateChangePage = DateTime.Now,
                DateCreatePage = DateTime.Now,
                SectionId = 1
            };
            MessageRabbitClass msg = new MessageRabbitClass
            {
                MethodName = "CreatePage",
                Data = page
            };
            var response = rpcClient.Call(msg, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response);

            #endregion

            #region Mark

            ///// Mark //////////
            Thread.Sleep(5000);
            MarkDto mark = new MarkDto {DateMark = DateTime.Now, MarkThis = 1, OwnerMark = "me", PageId = 1};
            MessageRabbitClass msg2 = new MessageRabbitClass
            {
                MethodName = "CreateMark",
                Data = mark
            };
            var response2 = rpcClient.Call(msg2, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response2);

            #endregion

            #region Comment

            ////// Comment //////
            Thread.Sleep(5000);
            CommentDto comment = new CommentDto {ContentComment = "aweosome", OwnerComment = "you", PageId = 10};
            MessageRabbitClass msg3 = new MessageRabbitClass
            {
                MethodName = "CreateComment",
                Data = comment
            };
            var response3 = rpcClient.Call(msg3, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response3);

            #endregion

            #region Section

            ////// Section //////
            Thread.Sleep(5000);
            SectionDto section = new SectionDto
            {
                NameSection = "ITSGOOD",
                DecriptionSection = "god",
                OwnerSection = "weare"
            };
            MessageRabbitClass msg4 = new MessageRabbitClass
            {
                MethodName = "CreateSection",
                Data = section
            };
            var response4 = rpcClient.Call(msg4, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response4);

            #endregion

            Console.ReadLine();
            rpcClient.Close();
        }
    }
}
