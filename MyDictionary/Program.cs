using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class Program
    {
        public static void Main()
        {
            var hash = new HashFunction();
            var hashfunc = hash.HashFunc<string>();
            var mydictionary = new My_Dictionary<string, int>(3, hashfunc);

            mydictionary.InsertChain("one", 1);
            mydictionary.InsertChain("two", 2);

            Console.WriteLine(mydictionary.GetValueChain("tw"));


        }
    }
}
