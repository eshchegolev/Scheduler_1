using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler_1
{
    class MyTask
    {
        public string Name = "NoName";
        public int[] Status = { 5, 7, 2 };
        public DateTime dateTime = DateTime.Now;

        public MyTask()
        {
            Name = "NoName!!!";
            dateTime = DateTime.Today;
        }

        public MyTask (string name)
        {
            Name = name;
        }
    }
}
