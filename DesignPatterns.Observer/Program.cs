using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Page page = new Page();
            page.Subscribe(new Subscriber("İbrahim"));
            page.Subscribe(new Subscriber("Tom"));
            page.Subscribe(new Subscriber("Cartion"));

            page.AddToPage("test1");
            page.UpdateToPage("test2");
            page.DeleteToPage();
        }
    }

    public enum ChangeType
    {
        Add,
        Update,
        Delete
    }

    public interface ISubscriber
    {
        void Update(Subscriber subscriber, Page page, ChangeType changeType);
    }

    public class Subscriber : ISubscriber
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void Update(Subscriber subscriber, Page page, ChangeType changeType)
        {
            Console.WriteLine("Subscriber Name:{0} Change Type:{1} Page Name:{2}", subscriber.Name, Enum.GetName(typeof(ChangeType), changeType), page.PageName);
        }
    }

    public class Page
    {
        public string PageName { get; set; }

        private readonly List<Subscriber> _subscribers;

        public Page()
        {
            _subscribers = new List<Subscriber>();
        }

        public bool UpdateToPage(string pageName)
        {
            this.PageName = pageName;
            Notify(ChangeType.Update);
            return true;
        }

        public bool AddToPage(string pageName)
        {
            this.PageName = pageName;
            Notify(ChangeType.Add);
            return true;
        }

        public bool DeleteToPage()
        {
            Notify(ChangeType.Delete);
            return true;
        }

        public void Subscribe(Subscriber subscriber)
        {
            this._subscribers.Add(subscriber);
        }

        public void UnSubscribe(Subscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
        }

        private void Notify(ChangeType changeType)
        {
            foreach (Subscriber subscriber in _subscribers)
            {
                subscriber.Update(subscriber, this, changeType);
            }
        }
    }
}
