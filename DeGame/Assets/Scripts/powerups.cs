using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class powerups : MonoBehaviour
{
    protected Animation anim;
    public AudioClip asteroidExplosion;
    public AudioClip NukeExplosionSound;
    public AudioClip ShieldEquipSound;
    bool powerup = false;
    float time, prevTime = 0f;
    bool flashing = true;
    bool flashActive = false;
    // Update is called once per frame
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (flashActive)
        {
            flash();
        }
        if(time > 2f && powerup){
            Time.timeScale = 1f;
            powerup = false;
        }
    }
    public void nukePowerUp(GameObject activatorObj)
    {
        activatorObj.GetComponent<Animator>().SetTrigger("Active");
        activatorObj.GetComponent<shooting_star>().isMoving = false;
        powerup = true;
        flashActive = true;
        flashing = true;
        print("nuke activated");
        bool audioPlayed = false;
        Destroy(activatorObj, 1.0f);
        foreach (var asteroid in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (asteroid.tag == "Enemy")  //
            //if (asteroid.name == "asteroid(Clone)")
            {
                if (!audioPlayed)
                {
                    audioPlayed = true;
                    AudioManager.instance.PlaySound(NukeExplosionSound, transform.position);
                }
                asteroid_float ast = asteroid.GetComponent<asteroid_float>();
                ast.DestroyAsteroid();
            }
        }
    }

    public void slowDownTime(GameObject activatorObj){
        print("Slow Down Time Activated");
        Destroy(activatorObj);
        powerup = true;
        time = 0f;
        flashActive = true;
        flashing = true;
        Time.timeScale = 0.3f;
    }

    public void shieldPowerUp(GameObject activatorObj)
    {
        print("Shield Power Up Activated");
        Destroy(activatorObj);
        powerup = true;
        time = 0f;
        bool audioPlayed = false;
        if (!audioPlayed)
        {
            audioPlayed = true;
            AudioManager.instance.PlaySound(ShieldEquipSound, transform.position);
        }
    }

    void flash()
    {
        GameObject whiteObj = GameObject.Find("white-screen");
        SpriteRenderer whiteScreen = whiteObj.GetComponent<SpriteRenderer>();
        if (flashing)
        {
            Color Opaque = new Color(1, 1, 1, 1);
            whiteScreen.color = Color.Lerp(whiteScreen.color, Opaque, 20 * Time.deltaTime);
            if (whiteScreen.color.a >= 0.9)
            {
                flashing = false;
            }
        }
        else
        {
            Color Transparent = new Color(1, 1, 1, 0);
            whiteScreen.color = Color.Lerp(whiteScreen.color, Transparent, 2 * Time.deltaTime);
            if (whiteScreen.color.a <= 0.05)
            {
                whiteScreen.color = Transparent;
                flashActive = false;
            }
        }

    }
}
