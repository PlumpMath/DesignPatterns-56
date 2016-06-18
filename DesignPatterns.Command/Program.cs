using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand updateCommand = new UpdatePostCommand();
            Controller controller = new Controller();

            controller.Invoke(updateCommand);
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class UpdatePostCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Update Post");
        }
    }

    public class AddPostCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Add to Post");
        }
    }

    public class Controller
    {
        public void Invoke(ICommand command)
        {
            command.Execute();
        }
    }
}
