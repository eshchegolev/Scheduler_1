﻿using System;

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

                Console.WriteLine("Возможные действия:");
                Console.WriteLine("* введите \"a\" (add)  для добавления задач в список.");
                Console.WriteLine("* введите \"d\" (del)  для удаления задач из списка.");
                Console.WriteLine("* введите \"e\" (edit) для редактирования задач в списке.");
                Console.WriteLine("* введите \"r\" (read) для считывания списка из файла.");
                Console.WriteLine("* введите \"s\" (save) для сохранения списка в файле.");
                Console.WriteLine("* введите \"q\" (quit) для выхода из программы.");

                str = Console.ReadLine();

                // Добавление задач в список
                if (str == "a" || str == "add")
                {
                    taskList.AddTask(ref taskList);
                }
                // Удаление задач из списка
                else if (str == "d" || str == "del")
                {
                    taskList.RemoveTask(ref taskList);
                }
                // Редактирование задач
                else if (str == "e" || str == "edit")
                {
                    taskList = taskList.EditTask(taskList);
                }
                // Считывание списка задач из файла
                else if (str == "r" || str == "read")
                {
                    taskList = taskList.ReadFileList();
                }
                // Сохранение списка задач в файл
                else if (str == "s" || str == "save")
                {
                    taskList.SaveFileList(taskList);
                }
                // Выход из цикла и завершение программы
                else if (str == "q" || str == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n$$$ Введите команду из предложенного списка $$$\n");
                    continue;
                }


                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"\nКоличество задач в списке = {taskList.NumTask}\n");

                if (taskList.NumTask > 0) Console.WriteLine("Текущий список задач следующий:");

                for (int i = 0; i < taskList.NumTask; i++)
                {
                    Console.WriteLine(taskList[i].Number.ToString() + ") " + taskList[i].MyTask);
                }

                Console.WriteLine("-----------------------------------\n");
            }
        }
    }
}
