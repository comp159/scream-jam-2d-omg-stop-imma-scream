using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isShaking = false;
    private float shakeDuration = 3.5f;
    private Vector3 startPos;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
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
                transform.position = startPos;
                isShaking = false;
                playerController.playerSpeed = 10;
            }
        }
    }

    public void StartShake()
    {
        startPos = transform.position;
        playerController.playerSpeed = 0;
        shakeDuration = 3.5f;
        isShaking = true;
    }
}
