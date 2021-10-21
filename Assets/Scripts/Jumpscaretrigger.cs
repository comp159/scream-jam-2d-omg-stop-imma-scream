using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscaretrigger : MonoBehaviour
{
    [SerializeField] private GameObject Jumpscare;
    [SerializeField] private AudioSource scream;
    [SerializeField] private int scareChancePercent;

    private GameObject jumpScare;
    private GameObject jumpScareBackground;
    private SpriteRenderer jumpScareRenderer;
    private SpriteRenderer jumpScareBackgroundRenderer;
    private bool isActive = false;
    private CameraController mainCamController;
    void Start()
    {
        jumpScare = GameObject.FindGameObjectWithTag("JumpScare");
        jumpScareBackground = GameObject.FindGameObjectWithTag("JumpScareBackground");
        jumpScareRenderer = jumpScare.GetComponent<SpriteRenderer>();
        jumpScareBackgroundRenderer = jumpScareBackground.GetComponent<SpriteRenderer>();
        mainCamController = FindObjectOfType<CameraController>();
        Debug.Log(scream.clip.length);//2.834467
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int rand = Random.Range(0, 101);
        if(other.tag == "Player" && rand < scareChancePercent){
            Debug.Log("JS");
            StartCoroutine(EndJumpScare());
            //Jumpscare.SetActive(true);
            //jumpScare.SetActive(true);
            //jumpScareBackground.SetActive(true);
            jumpScareRenderer.enabled = true;
            jumpScareBackgroundRenderer.enabled = true;
            mainCamController.StartShake();
            scream.PlayOneShot(scream.clip);
        }
    }

    private IEnumerator EndJumpScare()
    {
        isActive = true;
        yield return new WaitForSeconds(scream.clip.length);
        isActive = false;
        Debug.Log("JS End");
        //Jumpscare.SetActive(false);
        //jumpScare.SetActive(false);
        //jumpScareBackground.SetActive(false);
        jumpScareRenderer.enabled = false;
        jumpScareBackgroundRenderer.enabled = false;
    }
    
}
