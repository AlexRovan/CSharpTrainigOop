using System;

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

                if(String.IsNullOrEmpty(csvFilePath))
                {
                    throw new ArgumentException("В аргументах не указан путь до csv. Необходимо указать путь до Csv файла и путь выходного html файла.");
                }

                if (String.IsNullOrEmpty(htmlFilePath))
                {
                    throw new ArgumentException("В аргументах не указан путь до выходного html. Необходимо указать путь до Csv файла и путь выходного html файла.");
                }

                CsvConverter.ConvertToHtml(csvFilePath, htmlFilePath);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Произошла ошибка во время конвертации - {e}");
            }
        }
    }
}