using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public class Program
    {
        static void Main(string[] args)
        {
            PluginManager pluginManager = new PluginManager(new DataManagementPlugin());
            pluginManager.Call();
        }
    }

    public interface IPlugin
    {
        string PluginName { get;  } 
        string Version { get;  }
        void Call();
    }

    public class EnginePlugin : IPlugin
    {
        public string PluginName { get { return "Engine"; } }
        public string Version { get { return "1.0"; } }
        public void Call()
        {
            Console.WriteLine("Engine Plugin Called");
        }
    }

    public class DataManagementPlugin : IPlugin
    {
        public string PluginName { get { return "DataManagement"; } }
        public string Version { get { return "1.0"; }}
        public void Call()
        {
            Console.WriteLine("Data Management Plugin Called");
        }
    }

    public class PluginManager
    {
        private readonly IPlugin _plugin;

        public PluginManager(IPlugin plugin)
        {
            this._plugin = plugin;
        }

        public void Call()
        {
            _plugin.Call();
        }
    }
}
