using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollision : MonoBehaviour
{
 public static int item1;
 
 public static int item2;

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
        if (gameObject.CompareTag("Key"))
        {
            item1 += 1;
            Debug.Log("Collision with key Detected");
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Plank"))
        {
            item2 += 1;
            Debug.Log("Collision with ladder Detected");
            Destroy(gameObject);
        }
        
        
        
    }
}
