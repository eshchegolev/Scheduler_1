using System;


namespace Scheduler_1
{
    class TaskList
    {
        IndividualTask[] data;
        public TaskList()
        {
            data = new IndividualTask[20];
        }
        public TaskList(int param)
        {
            data = new IndividualTask[param];
        }

        // индексатор
        public IndividualTask this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public void AddTask(ref int NumTask, ref TaskList taskList)
        {
            Console.WriteLine("\nВведите все важные задачи на текущий день.\n" +
                              "Пустая строка должна завершить списток.");
            while (NumTask >= 0)
            {
                Console.Write((NumTask + 1).ToString() + ") ");
                string text = Console.ReadLine();

                if (text == "") break;

                taskList[NumTask] = new IndividualTask { Number = NumTask + 1, MyTask = text };
                NumTask++;
            }
        }

        public TaskList RemoveTask(ref int NumTask, TaskList taskList)
        {
            Console.WriteLine("\nВведите номер задачи, которую необходимо удалить.\n");

            int number = 0;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введите корректно номер задачи!");
            }

            if (number > NumTask || number < 1)
            {
                Console.WriteLine("В списке отсутствует задача с таким номером!\n" +
                    "Для продолжения работы нажмите \"Enter\".");
                Console.ReadLine();
                return taskList;
            }

            TaskList tempList = taskList;
            int count = 0;
            for (int i = 0; i < NumTask; i++)
            {
                if (i == (number - 1)) { continue; }
                tempList[count].MyTask = taskList[i].MyTask;
                count++;
            }

            NumTask--;
            return tempList;
        }

        public TaskList EditTask(ref int NumTask, TaskList taskList)
        {
            Console.WriteLine("\nВведите номер задачи, которую необходимо редактировать.\n");

            int number = 0;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введите корректно номер задачи!");
            }

            if (number > NumTask || number < 1)
            {
                Console.WriteLine("В списке отсутствует задача с таким номером!\n" +
                    "Для продолжения работы нажмите \"Enter\".");
                Console.ReadLine();
                return taskList;
            }

            Console.WriteLine("Редактируемая задача:  " + taskList[number-1].MyTask);
            Console.Write("Введите новый вариант: ");
            taskList[number - 1].MyTask = Console.ReadLine();

            return taskList;
        }

    }
}
