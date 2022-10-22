using System;
using System.Collections.Generic;
using System.Text;

namespace BT_202101125
{
    public class timkiem
    {

        public static int linear(int[] a, int value)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i]-value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int linearsentinel(int[] a, int value)
        {
            int last = a.Length- 1;
            if ((a[last]-value) == 0) { return last; }
            a[last] = value; ;
            int i;
            for (i = 0; (a[i]- value) != 0; i++) { }
            if (i == last) { return -1; }
            else
            {
                return i;
            }
        }
        public static int linearinordered(int[] a, int value)
        {
            for (int i = 0; ((a[i]- value) < 0) || (i < a.Length); i++)
            {
                if ((a[i]-value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int Binary(int[] a, int value)
        {
            int mid = 0;
            for (int left = 0, right = a.Length; left < right;)
            {
                mid = left + (right - left) / 2;
                if ((a[mid]-value) == 0)
                {
                    return mid;
                }
                else
                {
                    if ((a[mid]- value) < 0)
                    {
                        left = mid + 1;
                    }
                    else { right = mid - 1; }
                }
            }
            return -1;
        }
    }
}

