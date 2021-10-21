using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject rulesButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        Time.timeScale = 1;
    }

    void ActivateIns()
    {
        rulesButton.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "GameplayScreen");
    }

    public void ActivateInstruction()
    {
        SceneManager.LoadScene(sceneName: "InstructionsPage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
