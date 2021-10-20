using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscaretrigger : MonoBehaviour
{
    [SerializeField]private GameObject Jumpscare;
    [SerializeField] private AudioSource scream;
    [SerializeField] private int scareChancePercent;
    void Start()
    {
        
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
            Jumpscare.SetActive(true);
            scream.PlayOneShot(scream.clip);
        }
    }

    IEnumerator EndJumpScare()
    {
        yield return new WaitForSeconds(scream.clip.length);
        Debug.Log("JS End");
        Jumpscare.SetActive(false);
    }
}
