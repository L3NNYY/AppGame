using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baseStats : MonoBehaviour
{
    public float max_health = 100;
    private float current_health;
    public healthBar healthBarPlayer;
    private bool gameOver = false;
    public GameObject deathScreen;
    public GameObject onScreenUI;

    void Start()
    {
        //scoreText = GetComponent<Text>();
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health <= 0 && gameOver == false)
        {
            gameOver = true;
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            onScreenUI.SetActive(false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy") && current_health > 0)
        {
            current_health -= 5;
            healthBarPlayer.setSize((current_health / max_health));
            //print("Noo, you've been hit!");
            //print("You're on: " + current_health + " health points!");
        }
    }
}
