using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuyruk
{
    class Queue
    {
        private readonly int[] arr;
        private int rear = -1;
        private const int front = 0;
        public Queue(int capacity)
        {
            arr = new int[capacity];
        }
        public void Enqueue(int value)
        {
            if (rear == arr.Length-1)
                throw new IndexOutOfRangeException("Kuyruk dolu");
            arr[++rear] = value;
        }

        public int Dequeue()
        {
            if (rear == -1)
                throw new IndexOutOfRangeException("Kuyruk boş");
            for (int i = 0; i < rear; i++)
            {
                arr[i] = arr[i + 1];
            }
            rear--;
            return arr[front];
        }
        public int Peek()
        {
            if (rear == -1)
                throw new IndexOutOfRangeException("Kuyruk boş");
            return arr[front];
        }
        public int Count()
        {
            return rear + 1;
        }
        public void Clear()
        {
            rear = -1;
        }
        public bool IsEmpty()
        {
            return rear == -1;
        }
        public IEnumerable<int> GetEnumerator()
        {
            for (int i = 0; i <= rear; i++)
                yield return arr[i];
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(3);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            foreach (var item in queue.GetEnumerator())
                Console.WriteLine(item);
            Console.WriteLine("");
            queue.Dequeue();
            foreach (var item in queue.GetEnumerator())
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }
}
