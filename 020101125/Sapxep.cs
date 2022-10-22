using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class Sapxep
    {
        static void  Swap<T>(List<T> a,int i,int j)
        {
            T tam = a[i];
            a[i] = a[j];
            a[j] = tam;
        }
        public static void Interchange<T>(List<T> a,Comparison<T> comparison)
        {
            for(int i = 0,n= a.Count; i < n-1; i++)
            {
                for (int j= i+1; j<n; j++)
                {
                    if (comparison(a[i], a[j])>0)
                    {
                        Swap<T>(a, i,j);
                    }
                }
            }
        }
        public static void bubble<T>(List<T> a, Comparison<T> comparison)
        {
            for (int i = a.Count;i>0 ; i--)
            {
                for (int j= 0; j < i; j++)
                {
                    if (comparison(a[j], a[j+1]) >0)
                    {
                        Swap<T>(a, j, j+1);
                    }
                }
            }
        }
        public static void bubblewithswap<T>(List<T> a, Comparison<T> comparison)
        {
            bool swapped=false;
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
            for (int i = a.Count,n=i; i > n/2; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparison(a[j], a[j + 1]) >0)
                    {
                        Swap<T>(a, j, j + 1);
                    }
                    if (comparison(a[i-1], a[i])>0)
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
            q<T>(a,0,a.Count-1,comparison);
        }
        static void q<T>(List<T> a,int  left,int right ,Comparison<T> comparison)
        {
            if (left >= right) { return; }
            int mid = left + (right - left) / 2;
            T x=a[mid];
            for(int i=left,j=right;i<=j; i++)
            {
                while (comparison( a[i] , x)<0)
                {
                    i++;
                }
                while (comparison( a[j] , x)>0) j--;
                if (i <= j)
                {
                    Swap(a, i, j);
                    i++; j--;
                }
                if(left < j) q<T>(a,left,j,comparison);
                if(right > i) q<T>(a,i,right,comparison);
            }
            
        }


    }
}
