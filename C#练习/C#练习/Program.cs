using System;
using System.Collections.Generic;
using System.Linq;

//删除某一数组中的其他数组元素
public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        // Your brilliant solution goes here
        // It's possible to pass random tests in about a second ;)
        // 将数组转换为 List
        List<int> aList = new List<int>(a);
        // 删除指定元素
        foreach (int i in b)
        {
            aList.Remove(i);
        }
        // 转换回数组
        return a = aList.ToArray();
    }
}