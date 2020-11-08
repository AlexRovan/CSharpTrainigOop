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

                list.Add("1");
                list.Add("12");
                list.Add("123");
                list.Add("1234");
                list.Add("12345");

                SinglyLinkedList<string> copyList = list.Copy();

                Console.WriteLine($"Размер списка {list.GetLentgh()}");
                Console.WriteLine($"Значение первого элемента - {list.GetFirstElement()}");
                Console.WriteLine($"Значение элемента 2 индексом - {list.GetElementByIndex(2)}");
                Console.WriteLine($"Изменение значения элемента с 2 индексом. Старое значение - {list.SetElementByIndex("abv", 2)}");
                Console.WriteLine($"Удаление элемента с 3 индексом. Старое значение {list.Delete(3)}");

                list.Add("e1");
                list.Add("e2", 4);
                
                Console.WriteLine($"Удаление элемента по значению - {list.DeleteByValue("abv")}");
                Console.WriteLine($"Удаление первого элемента {list.Delete()}");
                list.Reversal();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Был введен неправильный индекс списка.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Неизвестная ошибка - {e}");
            }    
        }
    }
}
