using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winBackground;
    [SerializeField] private GameObject winText;
    private Inventory inv;
    private float waitTime = 3;
    private GameController _gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        inv = player.GetComponentInChildren<Inventory>();
        _gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && inv.HasKey())
        {
            Debug.Log("You WIN");
            StartCoroutine("winCondition");
        }
    }

    private IEnumerator winCondition()
    {
        winBackground.SetActive(true);
        winText.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        winBackground.SetActive(false);
        winText.SetActive(false);
        _gameController.QuitGame();
    }
}
