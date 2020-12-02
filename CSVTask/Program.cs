using System;
using System.IO;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string csvFilePath = args[0];
                string htmlFilePath = args[1];

                if (string.IsNullOrEmpty(csvFilePath))
                {
                    Console.WriteLine("Конвертация не возможна. В аргументах не указан путь до csv. Необходимо указать путь до Csv файла и путь выходного html файла.");
                    return;
                }

                if (string.IsNullOrEmpty(htmlFilePath))
                {
                    Console.WriteLine("Конвертация не возможна. В аргументах не указан путь до выходного html. Необходимо указать путь до Csv файла и путь выходного html файла.");
                    return;
                }

                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine($"CSV файл не найден");
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