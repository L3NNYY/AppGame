﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathScreen;
    public GameObject onScreenUI; 
    void Start()
    {
        pauseMenuUI.SetActive(false);
        deathScreen.SetActive(false);
        onScreenUI.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        onScreenUI.SetActive(true);
    }
    public void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        onScreenUI.SetActive(false);

    }
    public void PlayAgain()
    {
        Resume();
        SceneManager.LoadScene("GameScene");
        deathScreen.SetActive(false);
    }

    public void PlayAgain_Death()
    {
        SpriteRenderer render = GameObject.Find("blackFade").GetComponent<SpriteRenderer>();
        Color tmp = render.color;
        tmp.a = 0f;
        render.color = tmp;
        Resume();
        SceneManager.LoadScene("GameScene");
        deathScreen.SetActive(false);
    }

    public void Mute()
    {
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
        } 
        else if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }

    }
}
