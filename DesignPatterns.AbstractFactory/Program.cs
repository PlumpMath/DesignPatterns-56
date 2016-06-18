using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Factory mysqlFactory = new Factory(new MySqlDatabaseFactory());
            mysqlFactory.Run();

            Factory db2Factory = new Factory(new Db2DatabaseFactory());
            db2Factory.Run();
        }
    }

    public enum State
    {
        Open,
        Close
    }

    public interface IConnection
    {
        bool Connecte();
        bool Disconnect();
        State State { get; }
    }

    public interface ICommand
    {
        bool Execute(string query);
    }

    public class MySqlConection : IConnection
    {
        public bool Connecte()
        {
            return false;
        }

        public bool Disconnect()
        {
            return true;
        }

        public State State
        {
            get { return State.Open; }
        }
    }

    public class MySqlCommand : ICommand
    {
        public bool Execute(string query)
        {
            Console.WriteLine("Mysql query executed");
            return true;
        }
    }

    public class Db2Connection : IConnection
    {
        public bool Connecte()
        {
            return true;
        }

        public bool Disconnect()
        {
            return false;
        }

        public State State
        {
            get { return State.Open; }
        }
    }

    public class Db2Command : ICommand
    {
        public bool Execute(string query)
        {
            Console.WriteLine("Db2 query executed");
            return true;
        }
    }

    public interface IDatabaseFactory
    {
        IConnection CreateConnection();
        ICommand CreateCommand();
    }

    public class MySqlDatabaseFactory : IDatabaseFactory
    {
        public IConnection CreateConnection()
        {
            return new MySqlConection();
        }

        public ICommand CreateCommand()
        {
            return new MySqlCommand();
        }
    }

    public class Db2DatabaseFactory : IDatabaseFactory
    {
        public IConnection CreateConnection()
        {
            return new Db2Connection();
        }

        public ICommand CreateCommand()
        {
            return new Db2Command();
        }
    }

    public class Factory
    {
        private IDatabaseFactory _databaseFactory;
        private readonly IConnection _connection;
        private readonly ICommand _command;

        public Factory(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;

            _connection = databaseFactory.CreateConnection();
            _command = _databaseFactory.CreateCommand();
        }

        public void Run()
        {
            if (_connection.State == State.Open)
            {
                Console.WriteLine("execute query");
            }
        }
    }
}
