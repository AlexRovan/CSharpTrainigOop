using System;
using System.IO;

namespace CSVTask
{
    static class CsvConverter
    {
        public static void ConvertToHtml(string csvFilePath, string htmlFilePath)
        {
            try
            {
                using StreamReader reader = new StreamReader(csvFilePath);
                using StreamWriter writer = new StreamWriter(htmlFilePath);

                bool isEscapeSymbol = false;
                bool isEscapeCell = false;
                bool isNewCell = true;
                bool isNewLine = true;
          
                writer.Write("<!DOCTYPE HTML><html><head><meta charset=\"utf-8\"><title>Таблица</title></head><body><table border=\"1\">");
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (isNewLine)
                        {
                            writer.Write("<tr>");
                            isNewLine = false;
                        }

                        if (isNewCell)
                        {
                            writer.Write("<td>");
                            if (line[i] == '"')
                            {
                                isEscapeCell = true;
                                isNewCell = false;
                                continue;
                            }

                            isNewCell = false;
                            isEscapeCell = false;
                        }

                        if (!isEscapeCell)
                        {
                            if (line[i] == ',')
                            {
                                writer.Write("</td>");

                                isNewCell = true;

                                // последняя пустая ячейка в строке
                                if (i == line.Length - 1)
                                {
                                    isNewLine = true;
                                    writer.Write("<td></td></tr>");
                                }

                                continue;
                            }

                            if (i == line.Length - 1)
                            {
                                writer.Write(ReplaceTagEscaping(line[i]));

                                writer.Write("</td></tr>");

                                isNewCell = true;
                                isNewLine = true;

                                continue;
                            }

                            writer.Write(ReplaceTagEscaping(line[i]));
                            continue;
                        }

                        if (isEscapeSymbol)
                        {
                            if (line[i] == ',')
                            {
                                writer.Write("</td>");

                                isNewCell = true;
                                isEscapeSymbol = false;

                                // последняя пустая ячейка в строке
                                if (i == line.Length - 1)
                                {
                                    isNewLine = true;
                                    writer.Write("<td></td></tr>");
                                }

                                continue;
                            }

                            if (line[i] == '"')
                            {
                                writer.Write(line[i]);
                                isEscapeSymbol = false;
                                continue;
                            }

                            throw new FormatException("Некорректный CSV файл");
                        }

                        if (line[i] == '"')
                        {
                            if (i == line.Length - 1)
                            {
                                isNewCell = true;
                                isNewLine = true;

                                writer.Write("</td></tr>");
                                continue;
                            }

                            isEscapeSymbol = true;
                            continue;
                        }

                        writer.Write(ReplaceTagEscaping(line[i]));

                        if (i == line.Length - 1)
                        {
                            writer.Write("<br/>");
                        }
                    }
                }
                writer.Write("</table></body></html>");
            }
            catch (FormatException)
            {
                Console.WriteLine("CSV файл имеет не корректное содержание.");
                throw;
            }
        }

        private static string ReplaceTagEscaping(char ch)
        {
            if (ch == '<')
            {
                return "&lt;";
            }

            if (ch == '>')
            {
                return "&gt;";
            }

            if (ch == '&')
            {
                return "&amp;";
            }

            return ch.ToString();
        }
    }
}
