﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baseStats : MonoBehaviour
{
    private float current_health;
    private bool gameOver = false;
    public AudioClip earthExplosion;
    public bool godmode;
    static Vector3 originalScale;
    float damageTime;
    bool hitAnimEnding;
    public GameObject deathScreen;
    public GameObject onScreenUI;

    void Start(){
        originalScale = transform.localScale;
    }
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
        if(damageTime > 0){
            damageTime -= Time.deltaTime * 7;
            if(hitAnimEnding){
            transform.localScale = Vector3.Lerp(originalScale,originalScale*1.3f, damageTime);
            }else{
            transform.localScale = Vector3.Lerp(originalScale*1.3f,originalScale, damageTime);
            }
            if(damageTime <= 0 && !hitAnimEnding){
                hitAnimEnding = true;
                damageTime = 1f;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy") && !godmode)
        {
            damageTime = 1f;
            hitAnimEnding = false;
            Destroy(col.gameObject);
            HealthBarScript.health -= 5;
            AudioManager.instance.PlaySound(earthExplosion, transform.position);
        }
    }
}
