using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArray
{
    
    public class AutoArray
    {
        public const int DEFAULT_SIZE = 10;
        private const int INITIAL_INDEX = -1;

        private object[] data;
        private int topIndex;
        public IList<EventHandler<ElementAddedEventArgs>> ElementAddedListeners { get; set; } = new List<EventHandler<ElementAddedEventArgs>>();
        public IList<EventHandler<SizeChangedEventArgs>> SizeChangedListeners { get; set; } = new List<EventHandler<SizeChangedEventArgs>>();

        public AutoArray()
            : this(DEFAULT_SIZE)
        {
        }

        public AutoArray(int initialSize)
        {
            data = new object[initialSize];
            topIndex = INITIAL_INDEX;
        }

        public object this[int index]
        {
            get
            {
                Console.WriteLine("Top index is {0} " , topIndex);
                if (index <= topIndex)
                {
                    return data[index];
                }
                throw new IndexOutOfRangeException();
            }

            set
            {
                ResizeIfNeeded(index);
                if (index > topIndex)
                {
                    topIndex = index;
                    NotifyElementAdded(value);
                    NotifySizeChange(topIndex + 1);
                }
                data[index] = value;
            }
        }

        public void Add(object item)
        {
            topIndex++;
            ResizeIfNeeded(topIndex);
            data[topIndex] = item;
            NotifyElementAdded(item);
            NotifySizeChange(topIndex + 1);
        }

        private void ResizeIfNeeded(int index)
        {
            if (index + 1 > data.Length)
            {
                int newSize;

                if (index + 1 > 2 * data.Length)
                    newSize = (index + 1) * 2;
                else
                    newSize = 2 * data.Length;

                Array.Resize(ref data, newSize);
                Console.WriteLine("Data storage resized to {0}", newSize);
            }
        }

        private void NotifySizeChange(int newSize)
        {
            SizeChangedEventArgs args = new SizeChangedEventArgs(newSize);
            foreach (EventHandler<SizeChangedEventArgs> listener in SizeChangedListeners)
            {
                listener?.Invoke(this, args);
            }
        }

        private void NotifyElementAdded(object element)
        {
            ElementAddedEventArgs args = new ElementAddedEventArgs(element);
            foreach(EventHandler<ElementAddedEventArgs> listener in ElementAddedListeners)
            {
                listener?.Invoke(this, args);
            }
        }
    }

    public class SizeChangedEventArgs : EventArgs
    {
        public int newSize;
        public SizeChangedEventArgs(int newSize)
        {
            this.newSize = newSize;
        }
    }

    public class ElementAddedEventArgs : EventArgs
    {
        public object element;
        public ElementAddedEventArgs(object element)
        {
            this.element = element;
        }
    }
}
