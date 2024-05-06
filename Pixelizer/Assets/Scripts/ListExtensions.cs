using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Resize<T>(this List<T> list, int newSize, T defaultValue = default)
    {
        int count = list.Count;
        if (newSize < count)
        {
            list.RemoveRange(newSize, count - newSize);
        }
        else if (newSize > count)
        {
            if (newSize > list.Capacity)
                list.Capacity = newSize;
            list.AddRange(System.Linq.Enumerable.Repeat(defaultValue, newSize - count));
        }

    }
}