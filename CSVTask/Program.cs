using System;
using System.IO;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Аргументы программы указаны не полностью. Необходимо указать путь до Csv файла(1) и путь выходного html файла(2).");
                return;
            }

            try
            {
                string csvFilePath = args[0];
                string htmlFilePath = args[1];
         
                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine("CSV файл не найден");
                    return;
                }

                CsvConverter.ConvertToHtml(csvFilePath, htmlFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка во время конвертации - {e}");
            }
        }
    }
}