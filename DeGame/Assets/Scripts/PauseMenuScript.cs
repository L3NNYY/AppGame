using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathScreen;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayAgain()
    {
        Resume();
        SceneManager.LoadScene("GameScene");
        deathScreen.SetActive(false);
    }
}
