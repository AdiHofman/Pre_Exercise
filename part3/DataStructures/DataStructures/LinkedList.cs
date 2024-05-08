using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class LinkedList
    {
        public Node Head { get; set; }
        private Node _lastNode;

        public LinkedList(int value)
        {
            Head = new Node(value);
            _lastNode = Head;
        }
        
        // Adding a new value to the end of the Node list. O(1)
        public void Append(int value)
        {
            Node newHead = new Node(value);
            _lastNode.Next = newHead;
            _lastNode = newHead;
        }

        // Adding a new value to the start of the Node list.
        public void Prepend(int value)
        {
            Node newHead = new Node(value);
            newHead.Next = Head;
            Head = newHead;
        }

        // Deletes and returns the value from the end of the list.
        public int Pop()
        {
            //Node copy = Head.Copy();
            //while (copy.HasNext() && copy.Next.Next != null)
            //    copy.MoveNext();

            int lastValue = _lastNode.Value;

            //copy.Next = null;
            //_lastNode = copy;
            return lastValue;
        }

        // Deletes and returns the value from the start of the list.
        public int Unqueue()
        {
            int headValue = Head.Value;
            Head.MoveNext();

            return headValue;
        }

        // Retuns the node list as IEnumerable
        public IEnumerable<int> ToList()
        {
            Node copy = Head.Copy();
            yield return copy.Value;
            while (copy.HasNext())
            {
                copy.MoveNext();
                yield return copy.Value;
            }
        }

        // Retuns if the node list is circular ( the last organ of the list points on the first organ)
        public bool IsCircular()
        {
            return _lastNode.Next == Head;
        }

        // Sort the node list from small value to big value
        public void Sort()
        { 
        }

        // Returns the node with the biggest value. O(1)
        public Node GetMaxNode()
        {
            IEnumerable<int> list = ToList();
            int max_val = list.Max();
            return Head.GetNodeByValue(max_val);
        }

        // Returns the node with the smallest value. O(1)
        public Node GetMinNode()
        {
            IEnumerable<int> list = ToList();
            int min_val = list.Min();
            return Head.GetNodeByValue(min_val);
        }
    }
}
