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

                CsvConverter.ConvertToHtml(csvFilePath, htmlFilePath);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("В аргументах не указаны пути входного и выходного файла.");
                Console.WriteLine($"Ошибка {e}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Произошла ошибка во время конвертации - {e}");
            }
        }
    }
}