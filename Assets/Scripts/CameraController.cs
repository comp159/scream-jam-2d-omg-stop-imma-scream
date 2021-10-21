using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isShaking = false;
    private float shakeDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * .025f;
                shakeDuration -= Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(0, 0, -5);
                isShaking = false;
            }
        }
    }

    public void StartShake()
    {
        shakeDuration = 3f;
        isShaking = true;
    }
}
