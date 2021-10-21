using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    private bool playerDead = false;
    //private Transform prey;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private GameObject bloodlust;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
        bloodlust.SetActive(false);
        //prey = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (aiPath.remainingDistance < 7f)
        {
            bloodlust.SetActive(true);
            aiPath.maxSpeed = 9;
        }
        else
        {
            bloodlust.SetActive(false);
            aiPath.maxSpeed = 2;
        }
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