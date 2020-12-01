using System;

namespace ListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SinglyLinkedList<string> list = new SinglyLinkedList<string>();
          
                list.AddFirst("1");
                list.AddFirst("12");
                list.AddFirst("123");
                list.AddFirst("1234");
                list.AddFirst("12345");

                SinglyLinkedList<string> copyList = list.Copy();

                Console.WriteLine($"Размер списка {list.GetLength()}");
                Console.WriteLine($"Значение первого элемента - {list.GetFirst()}");
                Console.WriteLine($"Значение элемента 2 индексом - {list.GetByIndex(2)}");
                Console.WriteLine($"Изменение значения элемента с 2 индексом. Старое значение - {list.SetByIndex(2, "abv")}");
                Console.WriteLine($"Удаление элемента с 3 индексом. Старое значение {list.DeleteByIndex(3)}");

                list.AddFirst("e1");
                list.Add(5, "e2");
                
                Console.WriteLine($"Удаление элемента по значению - {list.DeleteByData(null)}");
                Console.WriteLine($"Удаление первого элемента {list.DeleteFirst()}");

                copyList.Reverse();
                Console.WriteLine(list.ToString());
                Console.WriteLine(copyList);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Неизвестная ошибка - {e}");
            }
        }
    }
}
