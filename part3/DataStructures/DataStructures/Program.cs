using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Linked List check
            LinkedList list = new LinkedList(6);
            list.Append(3);
            list.Append(5);
            list.Append(4);
            list.Append(1);
            list.Append(2);

            list.Sort();

            list.Prepend(1);

            list.Pop();

            list.Unqueue();

            Console.WriteLine(list.IsCircular());

            Console.WriteLine(list.GetMaxNode().Value);
            Console.WriteLine(list.GetMinNode().Value);

            // Numerical Expression check
            Console.OutputEncoding = System.Text.Encoding.UTF8; // for foreign languages

            NumericalExpression expression = new NumericalExpression(55, "es");
            Console.WriteLine(expression.ToString());
            Console.WriteLine(NumericalExpression.SumLetters(5, "es"));
            Console.WriteLine(NumericalExpression.SumLetters(new NumericalExpression(5, "es")));
        }
    }
}
