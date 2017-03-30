using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArray
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoArray array = new AutoArray();
            array.ElementAddedListeners.Add(new EventHandler(onElementAdded));
            for (int i = 0; i < 200; i++)
            {
                array[i] = i;
            }
            Console.ReadKey();
        }

        public static void onElementAdded(object sender, EventArgs args)
        {
            object element = ((ElementAddedEventArgs)args).element;
            Console.WriteLine("Element {0} was added", element);
        }

        public static void onSizeChanged(object sender, EventArgs at)
    }
}
