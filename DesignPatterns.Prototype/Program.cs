using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            IEngine dataManagementEngine = new DataManagementEngine("Data Management Engine");
            
            engine.Engines.Add(dataManagementEngine);
            Console.WriteLine("second clone");
            engine.Engines.Add(dataManagementEngine.Clone() as DataManagementEngine);


            IEngine viewEngine = new ViewEngine("View Engine");

            engine.Engines.Add(viewEngine);
            Console.WriteLine("second clone");
            engine.Engines.Add(viewEngine.Clone() as ViewEngine);

            Console.ReadLine();
        }
    }

    public interface IEngine
    {
        IEngine Clone();
    }

    public class ViewEngine : IEngine
    {
        public ViewEngine(string name)
        {
            Console.WriteLine(name);
        }

        public IEngine Clone()
        {
            return this.MemberwiseClone() as IEngine;
        }
    }

    public class DataManagementEngine : IEngine
    {
        public DataManagementEngine(string name)
        {
            Console.WriteLine(name);
        }

        public IEngine Clone()
        {
            return this.MemberwiseClone() as IEngine;
        }
    }

    public class Engine
    {
        public List<IEngine> Engines { get; set; }

        public Engine()
        {
            this.Engines = new List<IEngine>();
        }
    }
}
