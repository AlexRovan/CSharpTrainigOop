using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начало ряда: ");
            double mainRangeFrom = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите окончание ряда: ");
            double mainRangeTo = Convert.ToDouble(Console.ReadLine());

            Range mainRange = new Range(mainRangeFrom, mainRangeTo);

            while (true)
            {
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("1 - получить сумму ряда.");
                Console.WriteLine("2 - проверить вхождение числа.");
                Console.WriteLine("3 - полученить интервала-пересечение двух интервалов");
                Console.WriteLine("4 - получить объединения двух интервалов");
                Console.WriteLine("5 - полученить разность двух интервалов.");
                Console.WriteLine("0 - выход.");
                Console.Write("Выберете операцию операцию: ");

                int operation = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (operation)
                {
                    case 1:
                        Console.WriteLine($"Длина ряда {mainRange.GetLength()}");

                        Console.ReadKey();
                        break;

                    case 2:
                        {
                            Console.Write("Введите вещественное число: ");
                            double number = Convert.ToDouble(Console.ReadLine());

                            if (mainRange.IsInside(number))
                            {
                                Console.WriteLine($"Число {number} входит в диапазон ряда.");
                            }
                            else
                            {
                                Console.WriteLine($"Число {number} не входит в диапазон ряда.");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 3:
                        {
                            Console.Write("Введите начало второго ряда: ");
                            double rangeFrom = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго ряда: ");
                            double rangeTo = Convert.ToDouble(Console.ReadLine());

                            Range rangeIntersection = mainRange.GetRangeIntersection(rangeFrom, rangeTo);

                            if (rangeIntersection is null)
                            {
                                Console.WriteLine("Пересечений нет.");
                            }
                            else
                            {
                                Console.WriteLine($"Пересечение c {rangeIntersection.From} по {rangeIntersection.To}");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 4:
                        {
                            Console.Write("Введите начало второго ряда: ");
                            double rangeFrom = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго ряда: ");
                            double rangeTo = Convert.ToDouble(Console.ReadLine());

                            Range[] rangeSum = mainRange.GetRangeSum(rangeFrom, rangeTo);
                            Console.Write($"Сумма интервалов равна: ");

                            foreach (Range e in rangeSum)
                            {
                                Console.Write($"{e.From} - {e.To}, ");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 5:
                        {
                            Console.Write("Введите начало второго ряда: ");
                            double rangeFrom = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго ряда: ");
                            double rangeTo = Convert.ToDouble(Console.ReadLine());

                            Range[] rangeDifference = mainRange.GetRangeDifference(rangeFrom, rangeTo);


                            if (rangeDifference is null)
                            {
                                Console.WriteLine("Разность равна нулю");
                            }
                            else
                            {
                                Console.Write($"Разность интервалов равна: ");

                                foreach (Range e in rangeDifference)
                                {
                                    Console.Write($"{e.From} - {e.To}, ");
                                }
                            }

                            Console.ReadKey();
                            Console.WriteLine();
                        }

                        break;

                    case 0:

                        return;

                    default:

                        Console.WriteLine("Некорректная операция");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
