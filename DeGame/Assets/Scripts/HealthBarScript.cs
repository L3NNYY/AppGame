﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour { 

    Image healthBar;
    float maxHealth = 100f;
    public static float health;
    private bool gameOver = false;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start() {
        healthBar = gameObject.GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        healthBar.fillAmount = health / maxHealth;

        if (healthBar.fillAmount <= 0 && gameOver == false)
        {
            gameOver = true;
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
        }
    }
}
