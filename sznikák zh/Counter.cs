using System;
using System.Collections.Generic;
using System.Text;

namespace sznikák_zh
{

    public delegate void Delegate(int value);

    class Counter
    {
        int value = 10;
        int lastModified = 10;

        public Delegate Event;

        public int Value
        {
            get { return value; }
            set
            {
                if (value < 0)
                    throw new Exception("0-nál kisebb");
                this.value = value;
                lastModified = value;
            }
        }

        public void Step()
        {
            --value;

            if (value == 0)
            {
                Event(lastModified);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            counter.Event += Event;
            counter.Value = 3;
            for (int i = 0; i < 3; i++)
            {
                counter.Step();
            }
        }

        static void Event(int value)
        {
            Console.WriteLine(value);
        }
    }
}