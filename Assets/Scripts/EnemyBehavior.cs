using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    private bool playerDead = false;
    private Transform prey;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
        prey = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDead = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
        }
    }

    public bool GetPlayerStatus()
    {
        return playerDead;
    }
}