using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    static class StaticLibrary
    {
        public static void PrintList(string Title, List<int> list)
        {
            Console.Write(Title + " = ");
            foreach (int n in list)
            {
                Console.Write(n + ", ");
            }
            Console.WriteLine();
        }

        public static void PrintHorizontalLine()
        {
            Console.WriteLine("****************************************");
        }
    }
}
