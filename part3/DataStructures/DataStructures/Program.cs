using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
            list.Append(6);

            list.Unqueue();
            list.Unqueue();
            list.Unqueue();

            Console.WriteLine(list.Pop());
            Console.WriteLine(list.Pop());
            Console.WriteLine(list.Pop());

        }
    }
}
