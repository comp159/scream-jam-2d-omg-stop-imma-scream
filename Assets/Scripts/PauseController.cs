using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject quitGame;
    [SerializeField] private GameObject pausedText;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        quitGame.SetActive(false);
        pausedText.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        quitGame.SetActive(true);
        pausedText.SetActive(true);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        quitGame.SetActive(false);
        pausedText.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(sceneName: "TitleScreen");
    }
}
