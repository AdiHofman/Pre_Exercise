using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataStructures
{
    public class LinkedList
    {
        private Node _head;
        private Node _lastNode;
        private IEnumerable<int> _nodeList;
        private Node _maxNode;
        private Node _minNode;

        public LinkedList(int value)
        {
            _head = new Node(value);
            _lastNode = _head;
            _maxNode = _head;
            _minNode = _head;
            _nodeList = new List<int>() { value };
        }
        
        // Adding a new value to the end of the Node list. O(1)
        public void Append(int value)
        {
            Node newNode = new Node(value);
            _lastNode.Next = newNode;
            _lastNode = newNode;

            // adding the new value to the IEnumable list
            List<int> list = _nodeList.ToList();
            list.Add(value);
            _nodeList = list;

            // updating the max and min node
            if (value > _maxNode.Value)
                _maxNode = _lastNode;
            if (value < _minNode.Value)
                _minNode = _lastNode;
        }

        // Adding a new value to the start of the Node list.
        public void Prepend(int value)
        {
            Node newHead = new Node(value);
            newHead.Next = _head;
            _head = newHead;

            List<int> list = _nodeList.ToList();
            list.Insert(0, value);
            _nodeList = list;

            if (value > _maxNode.Value)
                _maxNode = _head;
            if (value < _minNode.Value)
                _minNode = _head;
        }

        // Deletes and returns the value from the end of the list.
        public int Pop()
        {
            int lastValue = _lastNode.Value;

            if (!_head.HasNext())
                _head = null;
            else
            {
                Node copy = _head.Copy();
                Node tempNode = _head;
                while (tempNode.HasNext())
                {
                    if (tempNode.Next.Next == null)
                    {
                        tempNode.Next = null;
                        _lastNode = tempNode;
                        break;
                    }

                    tempNode = tempNode.Next;
                }
            }

            // removing the last node from the IEnumable list
            List<int> list = _nodeList.ToList();
            list.RemoveAt(list.Count - 1);
            _nodeList = list;

            // updating the max and min node
            int maxvalue = _nodeList.Max();
            int minValue = _nodeList.Min();
            _maxNode = _head.GetNodeByValue(maxvalue);
            _minNode = _head.GetNodeByValue(minValue);

            return lastValue;
        }

        // Deletes and returns the value from the start of the list.
        public int Unqueue()
        {
            int headValue = _head.Value;
            _head = _head.Next;

            // removing the first node from the IEnumable list
            List<int> list = _nodeList.ToList();
            list.RemoveAt(0);
            _nodeList = list;

            // updating the max and min node
            int maxvalue = _nodeList.Max();
            int minValue = _nodeList.Min();
            _maxNode = _head.GetNodeByValue(maxvalue);
            _minNode = _head.GetNodeByValue(minValue);

            return headValue;
        }

        // Retuns the node list as IEnumerable
        public IEnumerable<int> ToList()
        {
            return _nodeList;
        }

        // Retuns if the node list is circular ( the last organ of the list points on the first organ)
        public bool IsCircular()
        {
            return _lastNode.Next == _head;
        }

        // Sort the node list from small value to big value
        public void Sort()
        {
            List<int> sortedValues = _nodeList.ToList();
            sortedValues.Sort();
            _nodeList = sortedValues;

            _head = new Node(sortedValues[0]);
            Node tempNode = _head;
            for (int i = 1; i < sortedValues.Count; i++)
            {
                tempNode.Next = new Node(sortedValues[i]);
                tempNode = tempNode.Next;
            }
            _lastNode = tempNode;

            // updating the max and min node
            int maxvalue = _nodeList.Max();
            int minValue = _nodeList.Min();
            _maxNode = _head.GetNodeByValue(maxvalue);
            _minNode = _head.GetNodeByValue(minValue);

        }

        // Returns the node with the biggest value. O(1)
        public Node GetMaxNode()
        {
            return _maxNode;
        }

        // Returns the node with the smallest value. O(1)
        public Node GetMinNode()
        {
            return _minNode;
        }
    }
}
