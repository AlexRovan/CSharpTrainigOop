using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace ArrayListHomeTask
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            List<string> fileLines = GetFileLines("..\\..\\..\\example_file.txt");
            Console.WriteLine("Список из линий файла");
            PrintList(fileLines);

            List<int> integerList1 = new List<int> { 1, 2, 3, 3, 4, 5, 6, 7, 8, 8, 8, 9, 9, 10 };

            DeleteEvenNumbersFromList(integerList1);
            Console.WriteLine("Список без нечётых чисел");
            PrintList(integerList1);

            List<int> integerList2 = GetListWithoutRepeating(integerList1);
            Console.WriteLine("Список без повторений");
            PrintList(integerList2);
        }

        public static List<string> GetFileLines(string filePath)
        {
            List<string> fileLines = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }

            return fileLines;
        }

        public static void DeleteEvenNumbersFromList(List<int> integerList)
        {
            for (int i = 0; i < integerList.Count; i++)
            {
                int number = integerList[i];

                if (number % 2 != 0)
                {
                    integerList.RemoveAt(i--);
                }
            }
        }

        public static List<int> GetListWithoutRepeating(List<int> integerList)
        {
            List<int> newIntegerList = new List<int>();

            foreach (int number in integerList)
            {
                if (!newIntegerList.Contains(number))
                {
                    newIntegerList.Add(number);
                }
            }

            return newIntegerList;
        }

        public static void PrintList(IList list)
        {
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}