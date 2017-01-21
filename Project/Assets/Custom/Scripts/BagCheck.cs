using UnityEngine;
using System.Collections;

public class BagCheck : MonoBehaviour {
    public int MHP;
    int HP;

    void Start()
    {
        HP = MHP;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bag")
        {
            Bag b = col.GetComponentInChildren<Bag>();
            if (b.isBad)
            {
                HP -= b.dangerLevel;
                //Strike Notification
            }
        }
    }
}
