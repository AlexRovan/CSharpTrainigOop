using System;
using System.Text;
using System.IO;

namespace CSVTask
{
    static class CsvConverter
    {
        public static void ToHtml(string filePath)
        {
            string htmlString = "<table>";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    StringBuilder sb = new StringBuilder();

                    bool isEscapSymbol = false;
                    bool isEscapCell = false;
                    bool isNewCell = true;
                    bool isNewLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (isNewLine)
                            {
                                htmlString += "<tr>";
                                isNewLine = false;
                            }

                            if (isNewCell)
                            {
                                htmlString += "<td>";
                                if (line[i] == '"')
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
                                if (line[i] == ',')
                                {
                                    htmlString += sb.ToString();
                                    sb.Clear();
                                    htmlString += "</td>";

                                    isNewCell = true;

                                    // последняя пустая ячейка в строке
                                    if (i == line.Length - 1)
                                    {
                                        isNewLine = true;
                                        htmlString += "<td></td></tr>";
                                    }

                                    continue;
                                }

                                if (i == line.Length - 1)
                                {
                                    sb.Append(line[i]);
                                    htmlString += sb.ToString();
                                    sb.Clear();
                                    htmlString += "</td></tr>";

                                    isNewCell = true;
                                    isNewLine = true;

                                    continue;
                                }

                                sb.Append(line[i]);
                                continue;
                            }

                            if (isEscapSymbol)
                            {
                                if (line[i] == ',')
                                {
                                    htmlString += sb.ToString();
                                    sb.Clear();
                                    htmlString += "</td>";

                                    isNewCell = true;
                                    isEscapSymbol = false;

                                    // последняя пустая ячейка в строке
                                    if (i == line.Length - 1)
                                    {
                                        isNewLine = true;
                                        htmlString += "<td></td></tr>";
                                    }

                                    continue;
                                }

                                if (line[i] == '"')
                                {
                                    sb.Append(line[i]);
                                    isEscapSymbol = false;
                                    continue;
                                }

                                throw new FormatException("Некорректный CSV файл");
                            }

                            if (line[i] == '"')
                            {
                                if (i == line.Length - 1)
                                {
                                    htmlString += sb.ToString();
                                    sb.Clear();

                                    isNewCell = true;
                                    isNewLine = true;

                                    htmlString += "</td></tr>";
                                    continue;
                                }

                                isEscapSymbol = true;
                                continue;
                            }

                            sb.Append(line[i]);

                            if (i == line.Length - 1)
                            {
                                sb.Append("<br/>");
                            }

                        }
                    }
                }
                htmlString += "</table>";
                string htmlFilePath = Path.ChangeExtension(filePath, "html");

                using (StreamWriter writer = new StreamWriter(htmlFilePath))
                {
                    writer.WriteLine(htmlString);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("CSV файл не найден.");
            }
            catch (FormatException)
            {
                Console.WriteLine("CSV файл имеет не корректное содержание.");
            }
        }
    }
}
