using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    public class SinglyLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public bool Remove(T value)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            Node current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
    internal class cs4
    {
        public static void task_4()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Console.WriteLine($"List contains 2:{list.Contains(2)}"); // виведе "List contains 2: True"

            list.Remove(2);

            foreach (int item in list)
            {
                Console.WriteLine("Item: " + item);
            }

            list.Clear();

            Console.WriteLine("List count: " + list.Count); // виведе "List count: 0"
        }
    }
}
