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
                Console.WriteLine("Список строк файла:");
                PrintList(fileLines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }

            List<int> numbersList = new List<int> { 1, 2, 3, 3, 4, 5, 6, 7, 8, 8, 8, 9, 9, 10, 11 };

            DeleteEvenNumbersFromList(numbersList);
            Console.WriteLine("Список без чётых чисел:");
            PrintList(numbersList);

            List<int> numbersListWithoutRepeat = GetListWithoutRepeat(numbersList);
            Console.WriteLine("Список без повторений:");
            PrintList(numbersListWithoutRepeat);
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

        public static void DeleteEvenNumbersFromList(List<int> numbersList)
        {
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] % 2 == 0)
                {
                    numbersList.RemoveAt(i);
                    i--;
                }
            }
        }

        public static List<int> GetListWithoutRepeat(List<int> numbersList)
        {
            List<int> numbersListWithoutRepeat = new List<int>(numbersList.Count);

            foreach (int number in numbersList)
            {
                if (!numbersListWithoutRepeat.Contains(number))
                {
                    numbersListWithoutRepeat.Add(number);
                }
            }

            return numbersListWithoutRepeat;
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