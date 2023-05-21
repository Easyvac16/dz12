using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace dz12
{
    public class PriorityQueue<T> : IEnumerable<Tuple<T, int>>
    {
        private List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

        public int Count => elements.Count;
        int priority;
        public void Enqueue(T item, int priority)
        {
            elements.Add(Tuple.Create(item, priority));
        }
        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }


        public T TopPriority()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            return bestItem;
        }

        public bool Contains(T item)
        {
            foreach (Tuple<T, int> element in elements)
            {
                if (EqualityComparer<T>.Default.Equals(element.Item1, item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            elements.Clear();
        }
        public override string ToString()
        {
            return "Element:" + elements + "Priority:" + priority;
        }
        public IEnumerator<Tuple<T, int>> GetEnumerator()
        {
            foreach (Tuple<T, int> element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    internal class cs2
    {
        public static void task_2()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(5, 1);
            queue.Enqueue(3, 2);
            queue.Enqueue(1, 3);
            Console.WriteLine("Черга:");
            foreach (Tuple<int, int> element in queue)
            {
                Console.WriteLine($"Елемент: {element.Item1}, Пріоритет: {element.Item2}");
            }
            Console.WriteLine();
            

            int highestPriorityElement = queue.TopPriority(); // отримуємо елемент з найвищим пріоритетом
            Console.WriteLine($"Елемент з найбільшим пріоритетом:{highestPriorityElement}");
            Console.WriteLine();

            queue.Dequeue();

            foreach (Tuple<int, int> element in queue)
            {
                Console.WriteLine($"Елемент: {element.Item1}, Пріоритет: {element.Item2}");
            }

        }
    }
}
