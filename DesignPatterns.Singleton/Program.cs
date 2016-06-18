using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManagement configuration1 = ConfigurationManagement.GetConfigurationManagementInstance();

            Console.WriteLine(configuration1.Id);

            ConfigurationManagement configuration2 = ConfigurationManagement.GetConfigurationManagementInstance();

            Console.WriteLine(configuration2.Id);

            Console.ReadLine();
        }
    }

    public class ConfigurationManagement
    {
        private static ConfigurationManagement _configurationManagement;
        public Guid Id { get; set; }

        private ConfigurationManagement(Guid id)
        {
            this.Id = id;
        }

        public static ConfigurationManagement GetConfigurationManagementInstance()
        {
            if(_configurationManagement ==null)
                _configurationManagement = new ConfigurationManagement(Guid.NewGuid());

            return _configurationManagement;
        }
    }
}
