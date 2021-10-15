using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rigBod;
    private Vector2 playerDirection;
    [SerializeField] private GameObject flashLight;
    private float rotateDegree = 90f;

    void Start()
    { 
        rigBod = GetComponent<Rigidbody2D>();
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if up is pressed = 1 if down is pressed = -1
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        // .normalized will ensure consistency of players movements
        playerDirection = new Vector2(directionX, directionY).normalized;
        
        
        PowerFlashLight(); //checks for when the user is turning on and off the flashlight
        MoveFlashLight(); //checks for when the user is rotating the flashlight (only while it is on)
    }

    void FixedUpdate()

    {
        //anything that must be applied to rb2d must be applied in fixed update
        rigBod.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }

    ////////////////////////////////////Flashlight stuff/////////////////////////////////////////////////
    void PowerFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F)) //checks if user is pressing the f key
        {
            //Debug.Log("User is pressing f");
            if (flashLight.activeInHierarchy == true) //turns off flashlight
            {
                //Debug.Log("Off");
                flashLight.SetActive(false);
            }
            else //turns on flashlight
            {
                //Debug.Log("On");
                flashLight.SetActive(true);
            }
        }
    }

    void MoveFlashLight()
    {
        if (flashLight.activeInHierarchy == true) //makes sure that flashlight is actually on
        {
            if (Input.GetKeyDown(KeyCode.Q)) //rotates flashlight left
            {
                flashLight.transform.Rotate(0,0,rotateDegree);
            }
            else if (Input.GetKeyDown(KeyCode.E)) //rotates flashlight right
            {
                flashLight.transform.Rotate(0,0,-rotateDegree);
            }
        }
    }
}