using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private EnemyBehavior enemy;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject gameOverBackground;
    // Start is called before the first frame update
    void Start()
    {
        GameObject e = GameObject.FindGameObjectWithTag("Enemy");
        enemy = e.GetComponent<EnemyBehavior>();
        gameOverText.SetActive(false);
        quitButton.SetActive(false);
        retryButton.SetActive(false);
        gameOverBackground.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetPlayerStatus() == true)
        {
            gameOverText.SetActive(true);
            quitButton.SetActive(true);
            retryButton.SetActive(true);
            gameOverBackground.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(sceneName: "TitleScreen");
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}