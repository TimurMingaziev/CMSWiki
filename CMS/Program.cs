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

