using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baseStats : MonoBehaviour
{
    private float current_health;
    private bool gameOver = false;
    public bool godmode;
    public GameObject deathScreen;
    public GameObject onScreenUI;

    // Update is called once per frame
    void Update()
    {
        if (HealthBarScript.health <= 0 && gameOver == false)
        {
            gameOver = true;
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            onScreenUI.SetActive(false);
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy") && !godmode)
        {
             HealthBarScript.health -= 5;
        }
    }
}
