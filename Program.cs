using System;

namespace Scheduler_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            Task x = new Task();
            Task y = new Task();

            Task[] a = new[] { x, y };

            Console.WriteLine(x.dateTime.Date);

            Console.WriteLine("Finish");
        }
    }
}
