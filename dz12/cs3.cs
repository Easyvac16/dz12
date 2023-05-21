using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] elements;
        private int head = -1;
        private int tail = -1;
        private int count = 0;
        private int startIndex = 0;
        public int Count => count;

        public CircularQueue(int capacity)
        {
            elements = new T[capacity];
        }


        public void Enqueue(T item)
        {
            if (count == elements.Length)
            {
                // Черга заповнена, додаємо на початок і зсуваємо інші елементи на одну позицію
                head = (head + 1) % elements.Length;
                elements[head] = item;
                tail = (tail + 1) % elements.Length;
                startIndex = (startIndex + 1) % elements.Length;
            }
            else if (count == 0)
            {
                // Черга порожня, додаємо на початок
                head = 0;
                tail = 0;
                elements[head] = item;
                startIndex = head;
            }
            else
            {
                // Додаємо на кінець черги
                tail = (tail + 1) % elements.Length;
                elements[tail] = item;
            }

            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Черга порожня");
            }

            T item = elements[head - 1];
            elements[head] = default(T);

            if (head == tail)
            {
                // Останній елемент в черзі
                head = -1;
                tail = -1;
            }
            else
            {
                // Зсуваємо вказівник на початок черги
                head = (head + 1) % elements.Length;
            }

            count--;
            return item;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Черга порожня");
            }

            return elements[head];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % elements.Length;
                if (EqualityComparer<T>.Default.Equals(elements[index], item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            // Очистити масив елементів та скинути вказівники на початок та кінець черги
            Array.Clear(elements, 0, elements.Length);
            head = -1;
            tail = -1;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % elements.Length;
                yield return elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class cs3
    {
        public static void task_3()
        {
            // Створюємо чергу з ємністю 5 елементів типу int
            CircularQueue<int> queue = new CircularQueue<int>(5);

            // Додаємо елементи до черги
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            foreach (int item in queue)
            {
                Console.WriteLine("Queue:" + item);
            }
            Console.WriteLine($"Count: {queue.Count}");

            // Додаємо ще один елемент, що повинен замінити перший елемент черги
            Console.WriteLine();
            queue.Enqueue(6);
            foreach (int item in queue)
            {
                Console.WriteLine("Queue:" + item);
            }
            Console.WriteLine();

            // Видаляємо два перших елементи черги
            int firstItem = queue.Dequeue();
            int secondItem = queue.Dequeue();

            // Виводимо кількість елементів у черзі
            Console.WriteLine($"Count: {queue.Count}");
            Console.WriteLine();

            // Виводимо на екран елементи, що залишилися у черзі
            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }

            
        }
    }
}
