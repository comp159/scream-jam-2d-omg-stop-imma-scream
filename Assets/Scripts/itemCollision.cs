using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollision : MonoBehaviour
{
 public static int item1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.CompareTag("Collectible"))
        {
            item1 += 1;
            Debug.Log("Collision Detected");
            Destroy(gameObject);
        }
        
    }
}
