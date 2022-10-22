using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class Sapxep
    {
        static void Swap<T>(List<T> a, int i, int j)
        {
            T tam = a[i];
            a[i] = a[j];
            a[j] = tam;
        }
        public static void Interchange<T>(List<T> a, Comparison<T> comparison)
        {
            for (int i = 0, n = a.Count; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (comparison(a[i], a[j]) > 0)
                    {
                        Swap<T>(a, i, j);
                    }
                }
            }
        }
        public static void bubble<T>(List<T> a, Comparison<T> comparison)
        {
            for (int i = a.Count; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparison(a[j], a[j + 1]) > 0)
                    {
                        Swap<T>(a, j, j + 1);
                    }
                }
            }
        }
        public static void bubblewithswap<T>(List<T> a, Comparison<T> comparison)
        {
            bool swapped = false;
            for (int i = a.Count; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparison(a[j], a[j + 1]) > 0)
                    {
                        Swap<T>(a, j, j + 1);
                    }
                }
            }
        }
        public static void shaker<T>(List<T> a, Comparison<T> comparison)
        {
            for (int i = a.Count, n = i; i > n / 2; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparison(a[j], a[j + 1]) > 0)
                    {
                        Swap<T>(a, j, j + 1);
                    }
                    if (comparison(a[i - 1], a[i]) > 0)
                    {
                        Swap<T>(a, j, j + 1);
                    }
                }
            }
        }
        public static void SelectionSort<T>(List<T> a, Comparison<T> comparison)
        {

        }
        public static void InsertionSort<T>(List<T> a, Comparison<T> comparison)
        {

        }
        public static void Quick<T>(List<T> a, Comparison<T> comparison)
        {
            q<T>(a, 0, a.Count - 1, comparison);
        }
        static void q<T>(List<T> a, int left, int right, Comparison<T> comparison)
        {
            if (left >= right) { return; }
            int mid = left + (right - left) / 2;
            T x = a[mid];
            for (int i = left, j = right; i <= j; i++)
            {
                while (comparison(a[i], x) < 0)
                {
                    i++;
                }
                while (comparison(a[j], x) > 0) j--;
                if (i <= j)
                {
                    Swap(a, i, j);
                    i++; j--;
                }
                if (left < j) q<T>(a, left, j, comparison);
                if (right > i) q<T>(a, i, right, comparison);
            }

        }
        #region HEAPSORT
        public static void shift<T>(List<T> a, int left, int right, Comparison<T> comparison)
        {
            //hieu chinh dong 
            if (left > right) { return; }
            int i = left, j = 2 * i + 1;
            T key = a[i];
            while (j <= right)
            {
                if ((j < right) && (comparison(a[j], a[j + 1]) < 0)) j++;
                if (comparison( a[i] , a[j])<0)
                {
                    Swap<T>(a, i, j);
                    i = j;
                    j = 2 * i + 1;
                }
                else break;
            }
            a[i] = key;
        }
        public static void heapify<T>(List<T> a,int n,Comparison<T> comparison)
        {
            //create 
          
            int i = n / 2 - 1;
            while (i >= 0)
            {
                shift<T>(a, i, n - 1,comparison);
                i--;
            }

        }
        public static void heapSort<T>(List<T> a, int n,Comparison<T> comparison)
        {
            heapify<T>(a,n,comparison);
            int r = n - 1;
            while (r >= 0)
            {
                Swap<T>(a, 0, r);
                r--;
                shift<T>(a, 0, r,comparison);
            }
        }
        #endregion
        #region MERGESORT
        public static void Merge<T>(List<T> a, List<T> b, int left, int mid, int right,Comparison<T> comparison)
        {
            int i = left;
            int j = right;
            int k = left;
            while (i < mid)
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
                a[k++] = (comparison(b[i] , b[j])<0) ? b[i++] : b[j--];
            }
        }
        public static void Msort<T>(List<T> a, List<T> b, int left, int right,Comparison<T> comparison)
        {
            if (left < right) return;
            int mid = left + (right - left) / 2;
            Msort(a, b, mid + 1, right,comparison);
            Msort(a, b, left, mid,comparison);
            Merge(a, b, left, mid, right,comparison);
        }
        public static void MergeSort<T>(List<T> a,Comparison<T> comparison)
        {
            List<T> b = new List<T>(a.Count);
            Msort(a, b, 0, a.Count,comparison);
        }

        public static void DirectMerge<T>(List<T> a, List<T> b, int n, int size, Comparison<T> comparison)
        {
            int left1 = 0, right1, left2, right2;
            while (left1 + size < n)
            {
                right1 = left1 + size - 1;
                if (right1 >= n) break;
                left2 = right1 + 1;
                right2 = left2 + size - 1;
                if (right2 >= n) right2 = n - 1;
                Merge<T>(a, b, left1, right1, right2,comparison);
                left1 = right2 + 1;
            }
        }
        public static void DirectMergeSort<T>(List<T> a, int n, Comparison<T> comparison)
        {
            int size = 1;
           List<T> b = new List<T>(n);
            while (size < n)
            {
                DirectMerge(a, b, n, size,comparison);
                size *= 2;
            }
        }
        public static int NaturalMerge<T>(List<T> a, List<T> b, int n, Comparison<T> comparison)
        {
            //RUN day con cuc dai khong giam 
            int numrun = 0;
            int left1 = 0, right1, left2, right2;
            while (left1 < n)
            {
                right1 = left1;
                while ((right1 < n - 1) && (comparison( a[right1], a[right1 + 1]) <=0))
                    right1++;

                numrun++;
                left2 = right1 + 1;
                if (left2 >= n) break;

                right2 = left2;
                while ((right2 < n - 1) && (comparison( a[right2] ,a[right2 + 1]) <=0)) right2++;

                if (right2 >= n) right2 = n - 1;
                Merge<T>(a, b, left1, right1, right2,comparison);
                left1 = right2 + 1;
                numrun++;

            }
            return numrun;
        }
        public static void NaturalMergeSort<T>(List<T> a, int n, Comparison<T> comparison)
        {
            int size = 1;
            List<T> b = new List<T> (n);
            int numrun;
            do
            {
                numrun = NaturalMerge(a, b, n,comparison);
            } while (numrun > 0);
        }
        #endregion
        
    }
}
