using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CSVTask
{
    static class CsvConverter
    {
        public static void ToHtml(string filePath)
        {
            List<List<string>> csvContentList = new List<List<string>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                csvContentList = ParseCsvToList(reader.ReadToEnd());
            }

            string htmlFilePath = Path.ChangeExtension(filePath, "html");

            ConvertToHtml(csvContentList, htmlFilePath);
        }

        private static void ConvertToHtml(List<List<string>> csvContentList, string htmlFilePath)
        {
            string htmlString = "<table>";

            foreach (List<string> line in csvContentList)
            {
                htmlString += "<tr>";
                foreach (string cell in line)
                {
                    htmlString += "<td>";
                    htmlString += cell;
                    htmlString += "<td>";
                }

                htmlString += "</tr>";
            }
            htmlString += "</table>";

            using (StreamWriter writer = new StreamWriter(htmlFilePath))
            {
                writer.WriteLine(htmlString);
            }
        }

        private static List<List<string>> ParseCsvToList(string csvString)
        {
            List<string> cells = new List<string>();
            List<List<string>> csvLines = new List<List<string>>();

            StringBuilder sb = new StringBuilder();

            bool isEscapSymbol = false;
            bool isEscapCell = false;
            bool isNewCell = true;
            bool isIgnorSymbol = false;

            foreach (char chr in csvString)
            {
                if (isIgnorSymbol)
                {
                    isIgnorSymbol = false;
                    continue;
                }

                if (isEscapSymbol)
                {
                    if (chr == '\r')
                    {
                        cells.Add(sb.ToString());
                        sb.Clear();

                        isNewCell = true;
                        isEscapSymbol = false;
                        isIgnorSymbol = true;

                        csvLines.Add(cells.ToList());
                        cells.Clear();
                        continue;
                    }

                    if (chr == ',')
                    {
                        cells.Add(sb.ToString());
                        sb.Clear();
                        isNewCell = true;
                        isEscapSymbol = false;
                        continue;
                    }

                    if (chr == '"')
                    {
                        sb.Append(chr);
                        isEscapSymbol = false;
                        continue;
                    }

                    throw new Exception("Некорректный CSV файл");
                }

                if (isNewCell)
                {
                    if (chr == '"')
                    {
                        isEscapCell = true;
                        isNewCell = false;
                        continue;
                    }

                    isNewCell = false;
                    isEscapCell = false;
                }

                if (!isEscapCell)
                {
                    if (chr == '\r')
                    {
                        cells.Add(sb.ToString());
                        sb.Clear();

                        isNewCell = true;
                        isIgnorSymbol = true;

                        csvLines.Add(cells.ToList());
                        cells.Clear();

                        continue;
                    }

                    if (chr == ',')
                    {
                        cells.Add(sb.ToString());
                        sb.Clear();
                        isNewCell = true;
                        continue;
                    }

                    sb.Append(chr);
                    continue;
                }

                if (chr == '"')
                {
                    isEscapSymbol = true;
                    continue;
                }

                sb.Append(chr);
            }

            cells.Add(sb.ToString());
            csvLines.Add(cells.ToList());

            return csvLines;
        }
    }
}
