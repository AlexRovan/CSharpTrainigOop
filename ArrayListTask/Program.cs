using System;

namespace ArrayListTask
{
    class Program
    {
        public static void Main()
        {
            ArrayList<string> dinosaurs = new ArrayList<string>();
            string[] array = new string[5];

            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            dinosaurs.CopyTo(1, array, 1, 2);
            foreach (var e in array)
            {
                if (e != null)
                {
                    Console.WriteLine(e);
                }
            }

            Console.WriteLine();
            Console.WriteLine(dinosaurs);

            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);
            Console.WriteLine("Index: {0}", dinosaurs.IndexOf("Compsognathus"));

            Console.WriteLine("Contains(\"Deinonychus\"): {0}", dinosaurs.Contains("Deinonychus"));

            Console.WriteLine("Insert(2, \"Compsognathus\")");
            dinosaurs.Insert(dinosaurs.Count, "Compsognathus");

            Console.WriteLine();
            Console.WriteLine(dinosaurs);

            Console.WriteLine("dinosaurs[3]: {0}", dinosaurs[3]);

            Console.WriteLine("Remove(\"Compsognathus\")");
            dinosaurs.Remove("Compsognathus");

            Console.WriteLine();
            Console.WriteLine(dinosaurs);

            dinosaurs.TrimExcess();
            Console.WriteLine("TrimExcess()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            dinosaurs.Clear();
            Console.WriteLine("Clear()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);
        }
    }
}
