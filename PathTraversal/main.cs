using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathTraversal
{
    class main
    {
        public static void Main(string[] args)
        {
            List<List<string>> lista = new List<List<string>>
            {
                new List<string> {"A", "B", "C" },
                new List<string> {"A", "B" },
                new List<string> {"A"}
            };

            List<List<string>> listb = new List<List<string>>
            {
                new List<string> {"A", "B", "C" },
                new List<string> {"A", "B" },
                new List<string> {"A"}
            };

            Console.WriteLine(lista.Intersect(listb).Count());
            Console.ReadLine();
        }
    }
}
