using System;
using System.IO;


namespace Scheduler_1
{
    class TaskList
    {
        //Количесвто задач в списке
        public int NumTask;
        
        //Максимально возможное количесвто задач в списке
        public const int MaxTask = 20;

        IndividualTask[] data;
        public TaskList()
        {
            data = new IndividualTask[MaxTask];
        }

        // Индексатор
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

        public void SaveFileList(TaskList taskList)
        {
            if (taskList.NumTask == 0)
            {
                Console.WriteLine("\n=== Список пуст! Нет задач для сохранения в файл! ===");
                return;
            }

            Console.WriteLine("Начало процесса записи списка в файл!");
            try
            {
                StreamWriter sw = new StreamWriter("List.txt");

                for (int i = 0; i < taskList.NumTask; i++)
                {
                    sw.Write(String.Format("{0,-5:0}", taskList[i].Number.ToString()));
                    sw.WriteLine(taskList[i].MyTask);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Процесс записи в файл завершён!");
            }
        }


        public TaskList ReadFileList()
        {
            TaskList taskList = new TaskList();
            string line;

            try
            {
                // Передаём путь к файлу (рядом с исполняемым) и имя файла конструктору StreamReader
                StreamReader sr = new StreamReader("List.txt");

                for (int i = 0; i < MaxTask; i++)
                {
                    line = sr.ReadLine();
                    if (line == null) break;

                    taskList[i] = new IndividualTask {
                        Number = int.Parse(line.Substring(0,5)),
                        MyTask = line.Substring(5) };

                    taskList.NumTask++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Процесс чтения из файла успешно завершён!");
            }

            return taskList;
        }


        public void AddTask(ref TaskList taskList)
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

        public void RemoveTask(ref TaskList taskList)
        {
            if (taskList.NumTask == 0)
            {
                Console.WriteLine("\n+++ Список пуст! Нет задач для удаления! +++");
                return;
            }

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
                return;
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
            return;
        }

        public TaskList EditTask(TaskList taskList)
        {
            if (taskList.NumTask == 0)
            {
                Console.WriteLine("\n### Список пуст! Нет задач для редактирования! ###");
                return taskList;
            }

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
