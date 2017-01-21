using UnityEngine;
using System;

public class Items : MonoBehaviour, IComparable
{
    public bool contraband;
    public int dangerLevel;
    public RectTransform RTransform;

    public int CompareTo(object obj)
    {
        Items i = obj as Items;
        Vector3 other = i.RTransform.localScale;
        Vector3 self = RTransform.localScale;
        if (other.x * other.y > self.x * self.y)
        {
            return 1;
        }
        else if (other.x * other.y < self.x * self.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    void Awake()
    {
        RTransform = GetComponent<RectTransform>();
    }
}

