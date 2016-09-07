using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMS.App;
using CMS.Inf;
using CMS.Model;
using MySql.Data.MySqlClient;
using NLog;
using RabbitMQ.Client;
using CMS.Inf.Migrations;


//////////В параметрах лучше передавать не object dtoObj а тот тип объекта который будет использоваться(например CreateComment(CommentDto comment))
/////////PageDto -- public virtual ICollection<CommentDto> Comments { get; set; } – зачем virtual и почему ICollection? Тут нужна конкретная коллекция(например List< >) или просто массив.
/////////UseCase – не самое удачное название, я предлагал что-то вида WikiService.
/////////IUseCase – перенести в App
/////////InitializeClass – непонятно что инициализирует, переменные statistic, usecase и rpc определены только внутри функции StartInit, после ее завершения они уничтожаются


namespace CMS
{
    class Program
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
            Logger.Log(LogLevel.Info, "Application started");
            InitializeClass init = new InitializeClass(Logger);
            init.Start();
            Console.WriteLine("[{Ctrl + C} to close]");
            Console.ReadKey();
        }
    }
}

