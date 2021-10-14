using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rigBod;
    private Vector2 playerDirection;
    


    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // if up is pressed = 1 if down is pressed = -1
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        // .normalized will ensure consistency of players movements
        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate()

    {

        //anything that must be applied to rb2d must be applied in fixed update
        rigBod.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);


       
        }
    }





