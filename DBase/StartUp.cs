using System;
using System.Linq;

namespace DBase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(new char[] { ' ', ',' }).Select(int.Parse).ToArray();
            var db = new Database<int>(integers);
            Print(db);

           

           

        }

        private static void Print(Database<int> db)
        {
            foreach (var num in db)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
        }
    }
}
