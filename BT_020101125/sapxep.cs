using System;
using System.Collections.Generic;
using System.Text;
using TuyenSinh;

namespace BT_020101125
{
    public class sapxep
    {
        static void Swap(int[] a, int i, int j)
        {
            int tam = a[i];
            a[i] = a[j];
            a[j] = tam;
        }
        public static void Interchange(int[] a)
        {
            for (int i = 0, n = a.Length; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((a[i] - a[j]) > 0)
                    {
                        Swap(a, i, j);
                    }
                }
            }
        }
        public static void bubble(int[] a)
        {
            for (int i = a.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((a[j] - a[j + 1]) > 0)
                    {
                        Swap(a, j, j + 1);
                    }
                }
            }
        }

        public static void Quick(int[] a)
        {
            q(a, 0, a.Length - 1);
        }
        public static void q(int[] a, int left, int right)
        {
            if (left > right) { return; }
            int mid = (left + right) / 2;
            int x = a[mid];
            int i = left, j = right;
            while (i <= j)
            {
                while (a[i] < x)
                {
                    i++;
                }
                while (a[j] > x) j++;
                if (i <= j)
                {
                    Swap(a, i, j);
                    i++; j--;
                }
            }
            if (left < j) q(a, left, j);
            if (i < right) q(a, i, right);
        }

        public static void shift(int[] a, int left, int right)
        {
            //hieu chinh dong 
            if (left > right) { return; }
            int i = left, j = 2 * i + 1;
            int key = a[i];
            while (j <= right)
            {
                if ((j < right) && (a[j] < a[j + 1])) j++;
                if (a[i] < a[j])
                {
                    Swap(a, i, j);
                    i = j;
                    j = 2 * i + 1;
                }
                else break;
            }
            a[i] = key;
        }
        public static void heapify(int[] a)
        {
            //create 
            int n = a.Length;
            int i = n / 2 - 1;
            while (i >= 0)
            {
                shift(a, i, n - 1);
                i--;
            }

        }
        public static void heapSort(int[] a, int n)
        {
            heapify(a);
            int r = n - 1;
            while (r >= 0)
            {
                Swap(a, 0, r);
                r--;
                shift(a, 0, r);
            }
        }

        public static void Merge(int[] a, int[] b, int left, int mid, int right)
        {
            int i = left;
            int j = right;
            int k = left;
            while (i <= mid)
            {
                b[k++] = a[i++];
            }
            while (j > mid)
            {
                b[k++] = b[j--];
            }
            i = left;
            j = right;
            k = left;
            while (i <= j)
            {
                a[k++] = (b[i] < b[j]) ? b[i++] : b[j--];
            }
        }
        public static void Msort(int[] a, int[] b, int left, int right)
        {
            if (left < right) return;
            int mid = left + (right - left) / 2;
            Msort(a, b, mid + 1, right);
            Msort(a, b, left, mid);
            Merge(a, b, left, mid, right);
        }
        public static void MergeSort(int[] a)
        {
            int[] b = new int[a.Length];
            Msort(a, b, 0, a.Length);
        }
        public static void DirectMerge(int[] a, int[] b, int n, int size)
        {
            int left1 = 0, right1, left2, right2;
            while (left1 + size < n)
            {
                right1 = left1 + size - 1;
                if (right1 >= n) break;
                left2 = right1 + 1;
                right2 = left2 + size - 1;
                if (right2 >= n) right2 = n - 1;
                Merge(a, b, left1, right1, right2);
                left1 = right2 + 1;
            }
        }
        public static void DirectMergeSort(int[] a, int n)
        {
            int size = 1;
            int[] b = new int[n];
            while (size < n)
            {
                DirectMerge(a, b, n, size);
                size *= 2;
            }
        }
        public static int NaturalMerge(int[] a, int[] b, int n)
        {
            //RUN day con cuc dai khong giam 
            int numrun = 0;
            int left1 = 0, right1, left2, right2;
            while (left1 < n)
            {
                right1 = left1;
                while ((right1 < n - 1) && (a[right1] <= a[right1 + 1]))
                    right1++;

                numrun++;
                left2 = right1 + 1;
                if (left2 >= n) break;

                right2 = left2;
                while ((right2 < n - 1) && (a[right2] <= a[right2 + 1])) right2++;

                if (right2 >= n) right2 = n - 1;
                Merge(a, b, left1, right1, right2);
                left1 = right2 + 1;
                numrun++;

            }
            return numrun;
        }
        public static void NaturalMergeSort(int[] a, int n)
        {
            int size = 1;
            int[] b = new int[n];
            int numrun;
            do
            {
                numrun = NaturalMerge(a, b, n);
            } while (numrun > 0);
        }

        public static int FindMax(int[] a, int n)
        {
            int max = a[0];
            for (int i = 0; i < n; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }
        public static int FindKthDigith(int n, int k)
        {
            while (k > 0)
            {
                n /= 10;
                k--;
            }
            return n % 10;
        }
        public static int GetNumDigith(int n)
        {
            int k = 0;
            while (n > 0)
            {
                n /= 10;
                k++;
            }
            return k;
        }
        public static void RadixlSort(int[] a, int n)
        {
            int k=GetNumDigith(FindMax(a,n));
            Queue<int>[] q = new Queue<int>[10];
            int coso = 10, i,Q,j;
            for (Q = 0; Q< 10; Q++)
            {
                q[Q] = new Queue<int>();
            }
            for(i=0;i<k;i++)
            {
                for(j = 0; j < n; j++)
                {
                    Q = FindKthDigith(a[j], i);
                    q[Q].Enqueue(a[j]);

                }
                j = 0;
                for (Q = 0; Q < coso; Q++)
                {
                    while (q[Q].Count > 0)
                    {
                        a[j++] = q[Q].Dequeue();
                    }
                }
            }

        }

        public static void QuichkSortwithStack(int[] a,int n )
        {
            Stack<int> stack = new Stack<int>();
            int left = 0, right = n - 1, mid;
            int i,j;
            stack.Push(right);
            stack.Push(left);
            while (stack.Count > 0)
            {
                left=stack.Pop();
                right=stack.Pop();

                i= left;
                j= right;


                mid=left+(right-left)/2;
                int x = a[mid];

                while (i <= j)
                {
                    while (a[i] < x)
                    {
                        i++;
                    }
                    while (a[j] > x) j--;
                    if (i <= j)
                    {
                        Swap(a, i, j);
                        i++; j--;
                    }
                }
                if (left < j)
                {
                    stack.Push(j);
                    stack.Push(left);
                }
                if (i < right)
                {
                    stack.Push(right);
                    stack.Push(i);
                }
            }
        }
        public static void MergeSortwithStack(int[]a,int n)
        {
            Stack<int> stack = new Stack<int>();
            int[] b=new int[n];
            int left=0, right=n-1, mid;
            stack.Push(right);
            stack.Push(left);

            //khu de quy ham Arsar????

            do
            {
                left=stack.Pop();
                right=stack.Pop();
                mid = left + (right - left) / 2;

                stack.Push(right);
                stack.Push(left);

                if (mid>left)
                {
                    stack.Push(left);
                    stack.Push(mid);
                }
                if (mid < right)
                {
                    stack.Push(right);
                    stack.Push(mid + 1);
                }
            }while(left< right);


            while(stack.Count > 0)
            {
                left = stack.Pop();
                right = stack.Pop();
                mid = left + (right - left) / 2;
                Merge(a, b, left, mid, right);
            }
        }
        public static void HeapSortwithPrioQueue(int[]a,int n)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>(n,(x,y)=>(x-y));
            int i;
            for (i = 0; i<n ; i++)
            {
                pq.Enqueue(a[i]);
            }
            for (i = 0; i < n; i++)
            {
                a[i]= pq.Dequeue(); 
            }

        }
       
    }
}
