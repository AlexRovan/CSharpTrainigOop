using System;
using LambdaTask;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>(5);

            hashTable.Add("123");
            hashTable.Add("Николай Фомин");
            hashTable.Add("Золоторёв Александр");
            hashTable.Add("Анатолий Суслов");
            hashTable.Add("Николай Устинов");
            hashTable.Add("Анатолий Сахаров");
            hashTable.Add("Иванов Иван");
            hashTable.Add(null);

            Console.WriteLine(hashTable);
            Console.WriteLine("Count: {0}", hashTable.Count);

            Console.WriteLine("Contains(\"person1\"): {0}", hashTable.Contains("Иванов Иван"));
            Console.WriteLine("Contains(\"person2\"): {0}", hashTable.Contains("Иванов Иван12"));

            Console.WriteLine($"Remove(\"person1\"): {hashTable.Remove("Анатолий Суслов")}");

            Console.WriteLine(hashTable);

            hashTable.Clear();

            Console.WriteLine("Count: {0}", hashTable.Count);
            Console.WriteLine(hashTable);
        }
    }
}
