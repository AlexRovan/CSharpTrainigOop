using System;

namespace RangeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начало диапазона: ");
            double rangeFrom1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите окончание диапазона: ");
            double rangrTo1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(rangeFrom1, rangrTo1);

            while (true)
            {
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("1 - получить длину диапазона.");
                Console.WriteLine("2 - проверить вхождение числа.");
                Console.WriteLine("3 - полученить интервала-пересечение двух интервалов");
                Console.WriteLine("4 - получить объединение двух интервалов");
                Console.WriteLine("5 - полученить разность двух интервалов.");
                Console.WriteLine("0 - выход.");
                Console.Write("Выберете операцию : ");

                int operation = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (operation)
                {
                    case 1:
                        Console.WriteLine($"Длина диапазона {range1.GetLength()}");

                        Console.ReadKey();
                        break;

                    case 2:
                        {
                            Console.Write("Введите вещественное число: ");
                            double number = Convert.ToDouble(Console.ReadLine());

                            if (range1.IsInside(number))
                            {
                                Console.WriteLine($"Число {number} входит в диапазон.");
                            }
                            else
                            {
                                Console.WriteLine($"Число {number} не входит в диапазон.");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 3:
                        {
                            Console.Write("Введите начало второго диапазона: ");
                            double rangeFrom2 = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго диапазона: ");
                            double rangeTo2 = Convert.ToDouble(Console.ReadLine());

                            Range range2 = new Range(rangeFrom2, rangeTo2);
                            Range intersection = range1.GetIntersection(range2);

                            if (intersection is null)
                            {
                                Console.WriteLine("Пересечений нет.");
                            }
                            else
                            {
                                Console.WriteLine($"Пересечение c {intersection.From} по {intersection.To}");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 4:
                        {
                            Console.Write("Введите начало второго диапазона: ");
                            double rangeFrom2 = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго диапазона: ");
                            double rangeTo2 = Convert.ToDouble(Console.ReadLine());
                            
                            Range range2 = new Range(rangeFrom2, rangeTo2);
                            Range[] union = range1.GetUnion(range2);
                            
                            Console.Write("Сумма диапазонов равна: ");

                            foreach (Range e in union)
                            {
                                Console.Write($"{e.From} - {e.To}, ");
                            }

                            Console.ReadKey();
                        }

                        break;

                    case 5:
                        {
                            Console.Write("Введите начало второго диапазона: ");
                            double rangeFrom2 = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите окончание второго диапазона: ");
                            double rangeTo1 = Convert.ToDouble(Console.ReadLine());
                            
                            Range range2 = new Range(rangeFrom2, rangeTo1);
                            Range[] difference = range1.GetDifference(range2);

                            if (difference.Length == 0)
                            {
                                Console.WriteLine("Разность диапазонов нулю");
                            }
                            else
                            {
                                Console.Write("Разность диапазонов равна: ");

                                foreach (Range e in difference)
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
