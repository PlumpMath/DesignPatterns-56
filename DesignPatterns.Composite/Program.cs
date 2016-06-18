using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Component
    {
        protected string Name { get; set; }

        public Component(string name)
        {
            this.Name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        private List<Component> _childrenComponents = new List<Component>();

        public Composite(string name):base(name)
        {
            
        }

        public override void Add(Component component)
        {
            this._childrenComponents.Add(component);
        }

        public override void Remove(Component component)
        {
            this._childrenComponents.Remove(component);
        }

        public override void Display(int depth)
        {
            foreach (var component in _childrenComponents)
            {
                Console.WriteLine(component.Display(1));
            }
        }
    }

}
