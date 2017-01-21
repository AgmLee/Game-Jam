using UnityEngine;
using System.Collections.Generic;

public class Bag : MonoBehaviour {

    public List<Items> contents;
    public MaxRectsBinPack.FreeRectChoiceHeuristic heu;
    public bool isBad;
    public int dangerLevel;
    MaxRectsBinPack bin;
    public RectTransform trans;

    void Start()
    {
        trans = GetComponent<RectTransform>();
        bin = new MaxRectsBinPack(Mathf.RoundToInt(trans.localScale.x), Mathf.RoundToInt(trans.localScale.y), false);
    }

    public void Insert(Items item)
    {
        contents.Add(item);
    }

    public void Pack()
    {
        if (contents.Count > 0)
        {
            contents.Sort();
            foreach (Items i in contents)
            {
                Rect r = new Rect();
                r = bin.Insert(Mathf.RoundToInt(i.RTransform.localScale.x), Mathf.RoundToInt(i.RTransform.localScale.y), heu);
                if (r.width <= 0)
                {
                    i.RTransform.localPosition = new Vector3(r.x, r.y, 0);
                    i.RTransform.localScale = new Vector3(r.width, r.height, 1);
                    continue;
                }
                else
                {
                    if (i.contraband)
                    {
                        isBad = true;
                    }
                    dangerLevel += i.dangerLevel;
                    i.RTransform.localPosition = new Vector3(r.x, r.y, 0);
                    i.RTransform.localScale = new Vector3(r.width, r.height, 1);
                }
            }
        }
    }
}
