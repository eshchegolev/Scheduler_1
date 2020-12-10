using System;

namespace Scheduler_1
{
    class WorkList
    {
        public void WorkTask()
        {
            // Создаём экземпляр класса, массив объектов, состоящий из всего списка дел.
            TaskList taskList = new TaskList();

            while (true)
            {
                string str;

                if (taskList.NumTask == 0)
                {
                    Console.WriteLine("Возможные действия:");
                    Console.WriteLine("* введите \"a\" (add) для добавления задач вручную.");
                    Console.WriteLine("* введите \"r\" (read) для считывания списка задач из файла.");
                    Console.WriteLine("* введите \"q\" (quit) для выхода из программы.");

                    str = Console.ReadLine();

                    if (str == "a" || str == "add")
                    {
                        taskList.AddTask(ref taskList);
                    }
                    else if (str == "r" || str == "read")
                    {
                        taskList = taskList.ReadFileList();
                    }
                    else if (str == "q" || str == "quit")
                    {
                        break;  // Выход из цикла и завершение программы
                    }
                }
                else
                {
                    Console.WriteLine("\n\nВозможные действия со списком задач:");
                    Console.WriteLine("* введите \"a\" (add) для добавления задач в список.");
                    Console.WriteLine("* введите \"d\" (del) для удаления задач из списка.");
                    Console.WriteLine("* введите \"e\" (edit) для редактирования задач в списке.");
                    Console.WriteLine("* введите \"s\" (save) для сохранения списка в файле.");
                    Console.WriteLine("* введите \"q\" (quit) для выхода из программы.");

                    str = Console.ReadLine();

                    // Добавляем задачи в список
                    if (str == "a" || str == "add")
                    {
                        taskList.AddTask(ref taskList);
                    }
                    // Удаляем задачи из списка
                    else if (str == "d" || str == "del")
                    {
                        taskList.RemoveTask(ref taskList);
                    }
                    // Редактируем задачи из списка
                    else if (str == "e" || str == "edit")
                    {
                        taskList = taskList.EditTask(taskList);
                    }
                    // Сохраняем задачи в файл
                    else if (str == "s" || str == "save")
                    {
                        Console.WriteLine(taskList.SaveFileList(taskList));
                        Console.ReadLine();
                    }
                    else if (str == "q" || str == "quit")
                    {
                        break;  // Выход из цикла и завершение программы
                    }
                }

                Console.WriteLine($"\nКоличество задач в списке = {taskList.NumTask}\n");

                if (taskList.NumTask > 0) Console.WriteLine("Текущий список задач следующий:");

                for (int i = 0; i < taskList.NumTask; i++)
                {
                    Console.WriteLine(taskList[i].Number.ToString() + ") " + taskList[i].MyTask);
                }
            }
        }
    }
}
