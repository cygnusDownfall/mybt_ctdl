using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_020101125
{
    public class PriorityQueue<T>
    {
        public int size;
        public Comparison<T> comparison;
        public int count;
        public T[] heap;
        public PriorityQueue(int size, Comparison<T>  comparison)
        {
            this.size = size;
            this.comparison = comparison;
            count = 0;
            heap = new T[size];
        }
        public bool IsFull()
        {
            return (count >= size);
        }
        public bool IsEmpty()
        {
            return (count == 0);
        }
        public void Enqueue(T value)
        {
            if (IsFull())
            {
                Console.WriteLine("Heap is full !");
                return;
            }
            heap[count++] = value;
            ShiftUp(heap, 0, count - 1, comparison);
        }
        public T Dequeue()
        {
            T  root = heap[0];
            if (IsEmpty())
            {
                Console.WriteLine("Heap is empty !");
                return root;
            }
            heap[0] = heap[count - 1];
            count--;
            ShiftDown(heap, 0, count - 1, comparison);
            return root;
        }
        public T Peek()
        {
            if (IsEmpty())
                Console.WriteLine("Heap is empty !");
            return heap[0];
        }
        public static void ShiftDown(T[] a, int left, int right, Comparison<T> comparison)
        {
            int i = left, j = 2 * i + 1;
            T key = a[i];
            while (j <= right)
            {
                if ((j < right) && (comparison(a[j], a[j + 1]) > 0))
                    j = j + 1;
                if (comparison(key, a[j]) > 0)
                {
                    a[i] = a[j];
                    i = j;
                    j = 2 * i + 1;
                }
                else
                    break;
            }
            a[i] = key;
        }
        public static void ShiftUp(T[] a, int left, int right, Comparison<T> comparison)
        {
            int j = right, i = (j-1)/2;
            T key = a[j];
            while ((i>=left) && (i<j))
            {
                if (comparison(a[i], key) < 0)
                    break;
                a[j] = a[i];                
                j = i;
                i = (j - 1) / 2;
            }
            a[j] = key;
        }
    }
}
