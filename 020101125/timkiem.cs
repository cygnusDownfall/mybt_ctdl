using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class timkiem
    {
        public static int linear<T>(List<T> a, T value, Comparison<T> comparison)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (comparison(a[i], value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int linearsentinel<T>(List<T> a, T value, Comparison<T> comparison)
        {
            int last = a.Count - 1;
            if (comparison(a[last], value) == 0) { return last; }
            a[last] = value; ;
            int i;
            for (i = 0; comparison(a[i], value) != 0; i++) { }
            if (i == last) { return -1; }
            else
            {
                return i;
            }
        }
        public static int linearinordered<T>(List<T> a, T value, Comparison<T> comparison)
        {
            for (int i = 0; (comparison(a[i], value) < 0) || (i < a.Count); i++)
            {
                if (comparison(a[i], value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int Binary<T>(List<T> a, T value, Comparison<T> comparison)
        {
            int mid=0;
            for(int left=0,right=a.Count;left<right;){
                mid=left+(right-left)/2;
                if(comparison(a[mid,value])==0 ){
                    return mid;
                }else{
                    if(comparison(a[mid],value)<0){
                        left=mid+1;
                    }else {right=mid-1}
                }
            }
        }
    }
}
