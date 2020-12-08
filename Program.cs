using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections;

namespace Scheduler_1
{

    class IndividualTask
    {
        public int Number { get; set; }
        public string MyTask { get; set; }
    }
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
    }

    class Program
    {
        static void Main(string[] args)
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
                    Console.WriteLine("* введите \"!\" для редактирования задач в списке.");
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
                    else if (str == "!")
                    {
                        Console.WriteLine("!!!");
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



    class ProgramQQ
    {
        static void MainQQ(string[] args)
        {
            // создаем каталог для файла
            string path = @"D:\Temp\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            // запись в файл
            using (FileStream fstream = new FileStream($"{path}note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }


            // чтение из файла
            using (FileStream fstream = File.OpenRead($"{path}note.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла:\n{textFromFile}");
            }

            Console.ReadLine();
        }
    }

    class ProgramZZ
    {
        static async Task MainZZ(string[] args)
        {

            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();


            TaskList taskList = new TaskList(3);
            taskList[0] = new IndividualTask { Number = 1, MyTask = "Tom" };
            taskList[1] = new IndividualTask { Number = 2, MyTask = "Bob" };
            taskList[2] = new IndividualTask { Number = 3, MyTask = "Jhon" };

//            IndividualTask bob = taskList[1];
//            Console.WriteLine(bob?.Name);




            // сохранение данных
            using (FileStream fs = new FileStream("TaskList.txt", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<IndividualTask>(fs, taskList[0]);
                await JsonSerializer.SerializeAsync<IndividualTask>(fs, taskList[1]);
                await JsonSerializer.SerializeAsync<IndividualTask>(fs, taskList[2]);

//                await JsonSerializer.SerializeAsync<TaskList>(fs, taskList);
                Console.WriteLine("Data has been saved to file");
            }

            // чтение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                TaskList restoredTaskList = new TaskList(3);
                restoredTaskList = await JsonSerializer.DeserializeAsync<TaskList>(fs);
//                Console.WriteLine($"Age: {restoredPerson.Number} Name: {restoredPerson.Name} ");
            }


            Console.ReadKey();
        }
    }





}
