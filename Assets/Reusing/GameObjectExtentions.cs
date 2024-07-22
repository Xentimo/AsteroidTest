using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static void SetActiveWithCheck(this GameObject go, bool active)
    {
        if (go.activeSelf == active)
            return;
        go.SetActive(active);
    }


    public static void Remove<T>(this List<T> list, Predicate<T> predicate)
    {
        int index = list.FindIndex(predicate);
        if (index != -1)
        {
            list.RemoveAt(index);
        }
    }

    public static bool TryAdd<T>(this List<T> list, Predicate<T> predicate, T addItem)
    {
        int index = list.FindIndex(predicate);
        if (index == -1)
        {
            list.Add(addItem);
            return true;
        }

        return false;
    }


    public static void Swap<T>(this List<T> list, int index1, int index2)
    {
        int count = list.Count;
        if (index1 > count - 1 || index1 < 0)
            return;
        if (index2 > count - 1 || index2 < 0)
            return;
        (list[index1], list[index2]) = (list[index2], list[index1]);
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        int index1 = 0;
        int index2 = list.Count;
        int rand = UnityEngine.Random.Range(index1, index2);
        return list[rand];
    }
    
    public  static bool IsPointInPolygon(Vector3[] polygon, Vector3 p, bool includeContour=true)
    {
        int N = polygon.Length;
        int counter = 0;
        int i;
        double xinters;
        Vector2 p1,p2;

        p1 = polygon[0];
        for (i=1;i<=N;i++) {
            p2 = polygon[i % N];
            if (p.y > Math.Min(p1.y,p2.y)) {
                if (p.y <= Math.Max(p1.y,p2.y)) {
                    if (p.x <= Math.Max(p1.x,p2.x)) {
                        if (p1.y != p2.y) {
                            xinters = (p.y-p1.y)*(p2.x-p1.x)/(p2.y-p1.y)+p1.x;
                            if (p1.x == p2.x || p.x <= xinters)
                                counter++;
                        }
                    }
                }
            }
            p1 = p2;
        }
        if (counter % 2 == 0)
            return false;
        else
            return true;
    }
}