using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSpawnerController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] spawnBoxes;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private GameObject plank;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1;)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector2(randX,randY);
            foreach (var box in spawnBoxes)
            {
                if (box.bounds.Contains(spawnPos))
                {
                    Instantiate(plank,spawnPos,Quaternion.identity);
                    //plank.transform.position = spawnPos;
                    i++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
