using System;
using LambdaTask;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<Person> hashTable = new HashTable<Person>(5);

            Person person1 = new Person("Иванов Иван", 33);
            Person person2 = new Person("Иванов Иван", 13);

            hashTable.Add(person1);
            hashTable.Add(new Person("Николай Фомин", 35));
            hashTable.Add(new Person("Золоторёв Александр", 17));
            hashTable.Add(new Person("Анатолий Суслов", 73));
            hashTable.Add(new Person("Николай Устинов", 22));
            hashTable.Add(new Person("Анатолий Сахаров", 402));
            hashTable.Add(new Person("Иванов Иван", 12));

            Console.WriteLine(hashTable);
            Console.WriteLine("Capacity: {0}", hashTable.Capacity);
            Console.WriteLine("Count: {0}", hashTable.Count);

            Console.WriteLine("Contains(\"person1\"): {0}", hashTable.Contains(person1));
            Console.WriteLine("Contains(\"person2\"): {0}", hashTable.Contains(person2));

            Console.WriteLine($"Remove(\"person1\"): {hashTable.Remove(person1)}");

            Console.WriteLine(hashTable);

            hashTable.Clear();
            Console.WriteLine("Capacity: {0}", hashTable.Capacity);
            Console.WriteLine("Count: {0}", hashTable.Count);
            Console.WriteLine(hashTable);

            Console.WriteLine($"Remove(\"person2\"): {hashTable.Remove(person2)}");
        }
    }
}
