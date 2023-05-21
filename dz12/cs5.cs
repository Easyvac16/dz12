using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public int Count => count;

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public bool Remove(T item)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                {
                    if (currentNode == head)
                    {
                        head = currentNode.Next;
                        if (head != null)
                            head.Previous = null;
                    }
                    else if (currentNode == tail)
                    {
                        tail = currentNode.Previous;
                        if (tail != null)
                            tail.Next = null;
                    }
                    else
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                    }

                    count--;
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public bool Contains(T item)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                    return true;

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class cs5
    {
        public static void task_5()
        {
                // Створення двозв'язкового списку типу int
                DoublyLinkedList<int> list = new DoublyLinkedList<int>();

                // Додавання елементів до списку
                list.AddFirst(1);
                list.AddLast(2);
                list.AddLast(3);

                // Перебір елементів списку і виведення їх на консоль
                foreach (int item in list)
                {
                    Console.WriteLine(item);
                }

                // Видалення елемента зі списку
                if (list.Remove(2) == true)
                {
                    Console.WriteLine("Element 2 removed");
                }

                //Виведення нового списку
                foreach (int item in list)
                {
                    Console.WriteLine(item);
                }


                // Перевірка наявності елемента у списку
                if (list.Contains(3) == true)
                {
                    Console.WriteLine("Element 3 present");
                }
                

                // Очищення списку
                list.Clear();
                Console.WriteLine("Count: " + list.Count);

                
            
        }
    }
}
