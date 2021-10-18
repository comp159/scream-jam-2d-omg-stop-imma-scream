using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    private bool playerDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDead = true;
        }
    }

    public bool GetPlayerStatus()
    {
        return playerDead;
    }
}