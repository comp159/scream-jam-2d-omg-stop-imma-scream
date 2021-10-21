using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isShaking = false;
    private float shakeDuration = 3.5f;
    private Vector3 startPos;
    private PlayerController _playerController;
    private EnemyBehavior _enemyBehavior;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _enemyBehavior = FindObjectOfType<EnemyBehavior>();
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
                _playerController.playerSpeed = 10;
                _enemyBehavior.SetAISpeed(2);
            }
        }
    }

    public void StartShake()
    {
        startPos = transform.position;
        _playerController.playerSpeed = 0;
        _enemyBehavior.SetAISpeed(0);
        shakeDuration = 3.5f;
        isShaking = true;
    }

    public bool GetIsShaking()
    {
        return isShaking;
    }
}
