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
        public static void Quick<T>(List<T> a, Comparison<T> comparison)
        {
            
        }
        static void q<T>(List<T> a,int  left,int right ,Comparison<T> comparison)
        {
            if (left >= right) { return; }
            int mid = left + (right - left) / 2;
            for(int i=left,j=right;i<=mid; i++)
            {
                if(comparison(a[i],a[mid]) > 0)
                {
                    while (comparison(a[j], a[mid])>=0) j--;
                    Swap<T>(a, i, j);
                }
            }
        }
    }
}
