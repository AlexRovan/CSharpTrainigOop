using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    class LambdaTask
    {
        static void Main(string[] args)
        {
            var personsList = new List<Person>
            {
                new Person("Иванов Иван", 33),
                new Person("Николай Фомин", 35),
                new Person("Золоторёв Александр", 17),
                new Person("Анатолий Суслов", 73),
                new Person("Николай Устинов", 22),
                new Person("Анатолий Сахаров", 40),
                new Person("Иванов Иван", 12)
            };

            var uniqueNamesList = personsList
                .Select(p => p.Name)
                .Distinct()
                .ToList();
            Console.WriteLine($"Имена: {string.Join(", ", uniqueNamesList)}");

            var personsWithAverageAgeUnder18 = personsList
                .Where(p => p.Age < 18)
                .Average(p => p.Age);
            Console.WriteLine($"Средний возраст: {personsWithAverageAgeUnder18}");

            var averageAgeByName = personsList
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Average(p => p.Age));
            Console.WriteLine($"Уникальные имена и их средний возраст: {string.Join(", ", averageAgeByName)}");

            var sortedNamesByAge = personsList
                .Where(p => (p.Age >= 20 && p.Age <= 45))
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name).ToList();

            Console.WriteLine($"Имена: {string.Join(", ", sortedNamesByAge)}");
        }
    }
}
