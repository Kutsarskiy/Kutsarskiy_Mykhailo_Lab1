using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Lb1
{

    public class Massive
    {

        public int UniqNum;
        static public int size;
        public int Size = size;
        public int[] Mass = new int[size];

        public Massive(int size)
        {
            Massive.size = size;
        }


        public void RandomNums()
        {
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                Mass[i] = random.Next(-15, 15);
            }

            Console.Write($"Массив: {string.Join(" ", Mass)} ");
        }


        public void RandomOrder()
        {
            Random randNum = new();
            int f = 1;
            int k = randNum.Next(0, 30);
            for (int i = 0; i < k; i++) 
            {
                int j = Mass[f];
                Mass[f] = Mass[f - 1];
                Mass[f - 1] = j;
                f++;
                if (f == size - 1)
                    f = 1;
            }

            Console.Write("Случайный порядок: ");
            Console.WriteLine(string.Join(" ", Mass));

        }


        public void UniqNumbers()
        {
            List<int> Unique = Mass.Distinct().ToList();
            UniqNum = Unique.Count;
            Console.WriteLine($"Уникальные номера: {UniqNum}");
        }


        public void PrintOutput()
        {
            int option = 0;
            while (option != 1)
            {
                Console.Write("\n\nНажмите [1] чтобы поменять порядок, [2] чтобы вывести уникальные номера и [3] чтобы выполнить пункты [1] и [2] \nодновременно: ");
                int new_choice = Convert.ToInt32(Console.ReadLine());

                if (new_choice == 1) { RandomOrder(); option = 0; }
                else if (new_choice == 2) { UniqNumbers(); option = 0; }
                else if (new_choice == 3) { RandomOrder(); UniqNumbers(); option = 1; }
                else
                {
                    Console.WriteLine("\nПоздравляем, вы всё сломали! \nПопробуем снова?\n");
                    option = 0;
                }
            }

        }



        public static void Serialization(Massive massive)
        {
            string objectToSerialize = JsonConvert.SerializeObject(massive);
            File.WriteAllText("/Users/Kutsarskiy/source/repos/Lab 1/file.json", objectToSerialize);

            string jsonText = File.ReadAllText("/Users/Kutsarskiy/source/repos/Lab 1/file.json");
            Console.WriteLine($"\nJSON файл: {jsonText}");
        }



        public static Massive Deserialization(string filename)
        {

            string json = File.ReadAllText("/Users/Kutsarskiy/source/repos/Lab 1/file.json");
            var massive = JsonConvert.DeserializeObject<Massive>(json);
            int size = massive.Size;
            return massive;
        }


        ~Massive() { }
    }
}

