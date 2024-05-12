using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public Node Copy()
        {
            Node newNode = new Node(Value);
            newNode.Next = Next;
            return newNode;
        }

        public bool HasNext() { return Next != null; }

        public Node GetNodeByValue(int value)
        {
            Node copy = this;
            if (copy.Value == value)
                return copy;
            while(copy.HasNext())
            {
                copy = copy.Next;
                if (copy.Value == value)
                    return copy;
            }
            return null;
        }
    }
}
