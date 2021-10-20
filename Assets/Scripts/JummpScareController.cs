using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JummpScareController : MonoBehaviour
{
    [SerializeField] private GameObject jumpScare;

    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private int numJumpScares;
    [SerializeField] private BoxCollider2D[] spawnArea;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numJumpScares;)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            Vector2 enemyPos = new Vector2(randX,randY);
            foreach (var box in spawnArea)
            {
                if (box.bounds.Contains(enemyPos))
                {
                    Instantiate(jumpScare,enemyPos,Quaternion.identity);
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
