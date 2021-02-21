using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExcelTask
{
    internal class ExcelTask
    {
        private static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var persons = new List<Person>
            {
                new Person(17, "Jhon", "Magnuson", "1232-122"),
                new Person(83, "Peter", "Dressler", "32-1272"),
                new Person(17, "Max", "Fray", "1223122"),
                new Person(17, "Gans", "Kastrop", "+71232122"),
                new Person(17, "German", "Milke", "1222")
            };

            try
            {
                using var excelPackage = new ExcelPackage();
                excelPackage.Workbook.Properties.Author = Environment.UserName;
                excelPackage.Workbook.Properties.Title = "Persons";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                var worksheet = excelPackage.Workbook.Worksheets.Add("persons");

                const int аgeColumn = 1;
                const int firstNameColumn = 2;
                const int lastNameColumn = 3;
                const int phoneColumn = 4;
                const int firstRow = 1;

                worksheet.Cells[firstRow, аgeColumn].Value = "Age";
                worksheet.Cells[firstRow, firstNameColumn].Value = "FirstName";
                worksheet.Cells[firstRow, lastNameColumn].Value = "LastName";
                worksheet.Cells[firstRow, phoneColumn].Value = "Phone";
                var row = 2;

                foreach (var person in persons)
                {
                    worksheet.Cells[row, аgeColumn].Value = person.Age;
                    worksheet.Cells[row, firstNameColumn].Value = person.FirstName;
                    worksheet.Cells[row, lastNameColumn].Value = person.LastName;
                    worksheet.Cells[row, phoneColumn].Value = person.Phone;

                    row++;
                }

                worksheet.Cells[firstRow, аgeColumn, firstRow, phoneColumn].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                worksheet.Cells[firstRow, аgeColumn, firstRow, phoneColumn].Style.Border.Left.Style = ExcelBorderStyle.Medium;
                worksheet.Cells[firstRow, аgeColumn, firstRow, phoneColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                worksheet.Cells[firstRow, аgeColumn, firstRow, phoneColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                worksheet.Cells[firstRow + 1, аgeColumn, firstRow + persons.Count, phoneColumn].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[firstRow + 1, аgeColumn, firstRow + persons.Count, phoneColumn].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[firstRow + 1, аgeColumn, firstRow + persons.Count, phoneColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[firstRow + 1, аgeColumn, firstRow + persons.Count, phoneColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[firstRow, аgeColumn, firstRow, phoneColumn].Style.Font.Bold = true;
                worksheet.Cells[firstRow, аgeColumn, firstRow + persons.Count, phoneColumn].Style.Border.BorderAround(ExcelBorderStyle.Double);

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var path = new FileInfo(@".\Persons.xlsx");
                excelPackage.SaveAs(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка выполнения программы: {e}");
            }
        }
    }
}
