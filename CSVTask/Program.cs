namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\..\\testCSV.csv";

            CsvConverter.ToHtml(filePath);
        }
    }
}
