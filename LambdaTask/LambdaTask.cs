using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    class LambdaTask
    {
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>()
            {
                                                new Person("Иванов Иван", 33),
                                                new Person("Николай Фомин", 35),
                                                new Person("Золоторёв Александр", 17),
                                                new Person("Анатолий Суслов", 73),
                                                new Person("Николай Устинов", 22),
                                                new Person("Анатолий Сахаров", 40),
                                                new Person("Иванов Иван", 12),
            };

            var uniqueNamesList = personsList.Select(p => p.Name).Distinct().ToList();
            Console.WriteLine($"Имена: {string.Join(",", uniqueNamesList)}");

            var averageAgePersonsUnder18 = personsList.Where(p => p.Age < 18).Average(p => p.Age);
            Console.WriteLine($"Средний возраст: {averageAgePersonsUnder18}");

            var uniquePersonWithAverageAge = personsList
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Average(p => p.Age));

            var sortedNameByAge = personsList
                .Where(p => (p.Age >= 20 && p.Age <= 40))
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name).ToList();

            Console.WriteLine($"Имена: {string.Join(",", sortedNameByAge)}");
        }
    }
}
