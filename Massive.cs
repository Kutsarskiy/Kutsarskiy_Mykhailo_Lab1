using System;
using System.Collections.Generic; 
using System.Linq;
using Newtonsoft.Json;
using System.IO;   

namespace Lb1
{

    public class Massive
    {

        private int UniqNum;
        private List<int> RandOrder;
        public int Size { get; set; }
        public List<int> Mass { get; set; }
      

        public Massive(int size)
        {
            Size = size;
            Mass = new List<int>();
        }


        public void RandomNums()
        {
            Random random = new();
            for (int i = 0; i < Size; i++)
            {
                Mass.Add(random.Next(-15, 15));
            }

            Console.Write($"Массив: {string.Join(" ", Mass)} ");
        }


        public void RandomOrder()
        {
            Random randNum = new();
            RandOrder = new List<int>();
            RandOrder = Mass.OrderBy(x => randNum.Next()).ToList();

            Console.Write("Случайный порядок: ");
            Console.WriteLine(string.Join(" ", RandOrder));

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
            return new Massive(size);
        }


        ~Massive() { }
    }
}
