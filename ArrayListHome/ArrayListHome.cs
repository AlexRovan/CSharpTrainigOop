using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHomeTask
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> fileLines = GetFileLines("..\\..\\..\\example_file.txt");
                Console.WriteLine("Список строк файла");
                PrintList(fileLines);

                List<int> numberList = new List<int> { 1, 2, 3, 3, 4, 5, 6, 7, 8, 8, 8, 9, 9, 10, 11 };

                DeleteEvenNumbersFromList(numberList);
                Console.WriteLine("Список без чётых чисел:");
                PrintList(numberList);

                List<int> numberListWithoutRepeat = GetListWithoutRepeating(numberList);
                Console.WriteLine("Список без повторений:");
                PrintList(numberListWithoutRepeat);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
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

        public static void DeleteEvenNumbersFromList(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 0)
                {
                    numberList.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        public static List<int> GetListWithoutRepeating(List<int> integerList)
        {
            List<int> numberListWithoutRepeat = new List<int>(integerList.Count);

            foreach (int number in integerList)
            {
                if (!numberListWithoutRepeat.Contains(number))
                {
                    numberListWithoutRepeat.Add(number);
                }
            }

            return numberListWithoutRepeat;
        }

        public static void PrintList(List<string> list)
        {
            foreach (string e in list)
            {
                Console.WriteLine(e);
            }
        }

        public static void PrintList(List<int> list)
        {
            Console.WriteLine($"{ string.Join(", ", list)}");
        }
    }
}