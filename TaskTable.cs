using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Scheduler_1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    class TaskTable
    {
        public async void FileWork()
        {
            // сохранение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person tom = new Person() { Name = "Tom", Age = 35 };
                await JsonSerializer.SerializeAsync<Person>(fs, tom);
                Console.WriteLine("Data has been saved to file");
            }

            // чтение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            }




            string text = "hello world";

            // запись в файл
            using (FileStream fstream = new FileStream(@"D:\note.dat", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] input = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(input, 0, input.Length);
                Console.WriteLine("Текст записан в файл");

                // перемещаем указатель в конец файла, до конца файла- пять байт
                fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока

                // считываем четыре символов с текущей позиции
                byte[] output = new byte[4];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine($"Текст из файла: {textFromFile}"); // worl

                // заменим в файле слово world на слово house
                string replaceText = "house";
                fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока
                input = Encoding.Default.GetBytes(replaceText);
                fstream.Write(input, 0, input.Length);

                // считываем весь файл
                // возвращаем указатель в начало файла
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine($"Текст из файла: {textFromFile}"); // hello house
            }
            Console.Read();
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
