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
    [SerializeField] private AudioClip footsteps;
    [SerializeField] private AudioClip fkeyboard;
    private AudioSource _audioSource;
    private Camera cam;
    private Transform lightAngle;
    public Animator animator;

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);

    }

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();// Add an AudioSource component to the object
        _audioSource.playOnAwake = false;//Setting not to play sound effects at the beginning
        fkeyboard = Resources.Load<AudioClip>("Audio/light switch"); // load the sound file
    }

    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        flashLight.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = footsteps;
        _audioSource.loop = true;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // if up is pressed = 1 if down is pressed = -1
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        // .normalized will ensure consistency of players movements
        playerDirection = new Vector2(directionX, directionY).normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            _audioSource.clip = fkeyboard;
            _audioSource.Play();
            
        }
        
        PowerFlashLight(); //checks for when the user is turning on and off the flashlight
        //MoveFlashLight(); //checks for when the user is rotating the flashlight (only while it is on)
        MoveFlashLightWithMouse();
        PlayFootstepSounds();
    }

    void FixedUpdate()

    {
        //anything that must be applied to rb2d must be applied in fixed update
        rigBod.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
        
        //animation stuff
        animator.SetFloat("Horizontal", playerDirection.x);
        animator.SetFloat("Vertical", playerDirection.y);
        animator.SetFloat("Speed", playerDirection.sqrMagnitude);
        /*if (playerDirection.x != 0 && playerDirection.y != 0) 
        {
            _audioSource.clip = footsteps;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            //AudioPlay(footsteps);
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
        }*/

    }


    private void PlayFootstepSounds()
    {
        if (playerDirection.x != 0 && playerDirection.y != 0)
        {
            _audioSource.clip = footsteps;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            //AudioPlay(footsteps);
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
        }
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
                    flashLight.transform.Rotate(0, 0, rotateDegree);
                }
                else if (Input.GetKeyDown(KeyCode.E)) //rotates flashlight right
                {
                    flashLight.transform.Rotate(0, 0, -rotateDegree);
                }
            }
        }

        void MoveFlashLightWithMouse()
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 mouseToPlayerPos = transform.position - mousePos;
            mouseToPlayerPos.z = 0;
            //float flashlightAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            float flashlightAngle = (Mathf.Atan2(mouseToPlayerPos.y, mouseToPlayerPos.x) * Mathf.Rad2Deg) + 90;
            flashLight.transform.rotation = Quaternion.AngleAxis(flashlightAngle, Vector3.forward);
        }
    }
