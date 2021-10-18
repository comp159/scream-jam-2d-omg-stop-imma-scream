using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private EnemyBehavior enemy;
    [SerializeField] private GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject e = GameObject.FindGameObjectWithTag("Enemy");
        enemy = e.GetComponent<EnemyBehavior>();
        gameOverText.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetPlayerStatus() == true)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}