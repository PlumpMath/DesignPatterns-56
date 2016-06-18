using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IScreen[] screens =
            {
                new WebScreem(),
                new WindowsScreen(),
            };

            foreach (IScreen screen in screens)
            {
                screen.Draw();
            }
        }
    }

    public interface IScreen
    {
        void Draw();
    }

    public class WindowsScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Windows drawing");
        }
    }

    public class WebScreem : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Web page is drawing");
        }
    }

    public enum ScreenType
    {
        Windows,
        Web
    }

    public class CreatorFactory
    {
        public IScreen ScreenFactory(ScreenType screenType)
        {
            IScreen screen = null;

            switch (screenType)
            {
                 case ScreenType.Web:
                    screen = new WebScreem();
                    break;
                 case ScreenType.Windows:
                    screen = new WindowsScreen();
                    break;
            }

            return screen;
        }
    }
}
