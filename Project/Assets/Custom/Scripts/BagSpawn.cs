using UnityEngine;
using System.Collections;

public class BagSpawn : MonoBehaviour {
    public Items[] itemTypes;
    public Bag[] bagTypes;

    public Bag current;
    private Bag[] que;

    int index = 0;
    public int minItems;
    public int maxItems;

    float timer = 0;
    float gameTime = 0;
    public float upSpeed = 5;
    public float spawnTime = 2;
    public float speed = 1;
    public float maxSpeed;

    void Start()
    {
        que = new Bag[5];

        que[index] = new Bag();
        int max = Random.Range(minItems, maxItems);
        for (int i = 0; i < max; i++)
        {
            que[index].Insert(itemTypes[Random.Range(0, itemTypes.Length)]);
        }
        que[index].Pack();
        index++;
    }

    void Update()
    {
        if (!current)
        {
            current = que[index];
            index--;
        }
        float DT = Time.deltaTime;
        timer += DT;
        gameTime += DT;
        if (!que[5] && timer > (spawnTime / speed))
        {
            que[index] = new Bag();
            int max = Random.Range(minItems, maxItems);
            for (int i = 0; i < max; i++)
            {
                que[index].Insert(itemTypes[Random.Range(0, itemTypes.Length)]);
            }
            que[index].Pack();
            index++;
            timer = 0;
        }
        if (gameTime > upSpeed)
        {
            speed += 1;
            gameTime = 0;
            //Speed up notification
        }
    }
}
