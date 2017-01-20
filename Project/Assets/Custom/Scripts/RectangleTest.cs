using UnityEngine;
using System.Collections.Generic;

public class RectangleTest : MonoBehaviour {

    MaxRectsBinPack bin;
    
    public List<RectTransform> rects;

    public RectTransform binRect;
    public MaxRectsBinPack.FreeRectChoiceHeuristic heu;

    void Awake()
    {
        bin = new MaxRectsBinPack(Mathf.RoundToInt(binRect.lossyScale.x), Mathf.RoundToInt(binRect.lossyScale.y));
    }

    void Start()
    {
        foreach (RectTransform rect in rects)
        {
            Rect r = bin.Insert(Mathf.RoundToInt(rect.localScale.x), Mathf.RoundToInt(rect.localScale.y), heu);
            rect.localPosition = new Vector3(r.x, r.y, 0);
            rect.localScale = new Vector3(r.width, r.height, 1);
        }
    }
}
