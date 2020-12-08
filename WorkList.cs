using System;

namespace Scheduler_1
{
    class WorkList
    {
        public void WorkTask()
        {
            // Вводим переменную, отображающую количество задач
            int NumTask = 0;

            // Создаём экземпляр класса, массив объектов, состоящий из всего списка дел.
            TaskList taskList = new TaskList();

            while (true)
            {
                string str;

                if (NumTask == 0)
                {
                    Console.WriteLine("Введите \"+\" для добавления задач вручную и нажмите \"Enter\".");
                    Console.WriteLine("Либо введите \"r\" для считывания списка задач из файла и нажмите \"Enter\".");

                    str = Console.ReadLine();

                    if (str == "+")
                    {
                        // Добавляем задачи в список вручную
                        taskList.AddTask(ref NumTask, ref taskList);
                    }
                    else if (str == "r")
                    {
                        Console.WriteLine("Пока нет возможности прочитать список из файла");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nВозможные действия со списком задач:");
                    Console.WriteLine("* введите \"+\" для добавления задач в список.");
                    Console.WriteLine("* введите \"-\" для удаления задач из списка.");
                    Console.WriteLine("* введите \"e\" для редактирования задач в списке.");
                    Console.WriteLine("* введите \"f\" для сохранения списка в файле.");
                    Console.WriteLine("* введите \"q\" для выхода из программы.");

                    str = Console.ReadLine();

                    // Добавляем задачи в список
                    if (str == "+")
                    {
                        taskList.AddTask(ref NumTask, ref taskList);
                    }
                    // Удаляем задачи из списка
                    else if (str == "-")
                    {
                        taskList = taskList.RemoveTask(ref NumTask, taskList);
                    }
                    // Редактируем задачи из списка
                    else if (str == "e")
                    {
                        taskList = taskList.EditTask(ref NumTask, taskList);
                    }
                    // Сохраняем задачи в файл
                    else if (str == "f")
                    {
                        Console.WriteLine("Список задач успешно сохранён в файле \"file.txt\",\n" +
                            "для продолжения работы нажмите \"Enter\".");
                        Console.ReadLine();
                    }
                    else if (str == "q")
                    {
                        break;  // Выход из цикла и завершение программы
                    }
                }

                Console.WriteLine($"\nКоличество введённых задач = {NumTask}\n");

                if (NumTask > 0) Console.WriteLine("Текущий список задач следующий:");

                for (int i = 0; i < NumTask; i++)
                {
                    Console.WriteLine(taskList[i].Number.ToString() + ") " + taskList[i].MyTask);
                }
            }
        }
    }
}
