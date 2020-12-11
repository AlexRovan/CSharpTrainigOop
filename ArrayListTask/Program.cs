using System;
using System.Collections.Generic;

namespace ArrayListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list2 = new List<string>(5);

            list2.Add("123");
            list2.Add("1233");
            int s = list2.IndexOf("1");
            string a = list2[5];
            ArrayList<string> list = new ArrayList<string>(10);

            list.Add("123");
            list.Add("123");
            list.Add("123");
            list.Add("123");
            list[6] = "123";
            list.Insert(2, "4");
             Console.WriteLine(list.Count);
            Console.WriteLine(list[6]);
        }
    }
}
