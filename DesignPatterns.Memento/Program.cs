using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator<int> originator =new Originator<int>();
            originator.State = 1;
            CareTaker<int> careTaker = new CareTaker<int>();
            careTaker.Memento = originator.Redo();

            Console.WriteLine(originator.State.ToString());

            originator.State = 2;
            Console.WriteLine(originator.State.ToString());

            originator.Undo(careTaker.Memento);

            Console.WriteLine(originator.State.ToString());
        }
    }

    public class Memento<T>
    {
        public T State { get; private set; }

        public Memento(T state)
        {
            this.State = state;
        }
    }

    public class Originator<T>
    {
        public T State { get; set; }

        public Memento<T> Redo()
        {
            return new Memento<T>(this.State);
        }

        public void Undo(Memento<T> memento)
        {
            this.State = memento.State;
        }
    }

    public class CareTaker<T>
    {
        public Memento<T>  Memento { get; set; }
    }

}
