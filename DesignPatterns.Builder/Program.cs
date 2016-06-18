using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginBuilder builder = null;

            PluginDirector pluginDirector = new PluginDirector();
            
            builder = new ViewPluginBuilder();
            pluginDirector.Costruct(builder);

            builder = new EnginePluginBuilder();
            pluginDirector.Costruct(builder);

            Console.ReadLine();
        }
    }

    public class Plugin
    {
        public string PluginName { get; set; }
        public string PluginPath { get; set; }
        public Permission Permission { get; set; }

        public override string ToString()
        {
            return this.PluginName;
        }
    }

    public enum Permission
    {
        Admin,
        Personel,
        Anonymous,
        Engine
    }

    public abstract class PluginBuilder
    {
        protected Plugin Plugin { get; set; }

        public abstract void LoadPlugin();

        public abstract void EnabledPlugin();

        public abstract void DisabledPlugin();
    }

    public class ViewPluginBuilder : PluginBuilder
    {
        public ViewPluginBuilder()
        {
            this.Plugin = new Plugin()
            {
                PluginName = "ViewPlugin",
                PluginPath = "~/Share/",
                Permission = Permission.Anonymous
            };
        }

        public override void LoadPlugin()
        {
            Console.WriteLine("View Plugin is load");
        }

        public override void EnabledPlugin()
        {
            Console.WriteLine("View plugin is enablend");
        }

        public override void DisabledPlugin()
        {
            Console.WriteLine("View plugin is diablend");
        }
    }

    public class EnginePluginBuilder : PluginBuilder
    {
        public EnginePluginBuilder()
        {
            this.Plugin = new Plugin()
            {
                PluginName = "EnginePlugin",
                PluginPath = "~/Share/",
                Permission = Permission.Engine
            };
        }

        public override void LoadPlugin()
        {
            Console.WriteLine("Engine Plugin is load");
        }

        public override void EnabledPlugin()
        {
            Console.WriteLine("Engine plugin is enablend");
        }

        public override void DisabledPlugin()
        {
            Console.WriteLine("Engine plugin is diablend");
        }
    }

    public class PluginDirector
    {
        public void Costruct(PluginBuilder pluginBuilder)
        {
            pluginBuilder.LoadPlugin();
            pluginBuilder.EnabledPlugin();
            pluginBuilder.DisabledPlugin();
        }
    }
    
}
