using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class powerups : MonoBehaviour
{
    protected Animation anim;
    public AudioClip asteroidExplosion;
    public AudioClip NukeExplosionSound;
    public AudioClip ShieldEquipSound;
    public GameObject powerupTimer;
    public GameObject powerupTimerText;
    public GameObject Earth;
    public Material MetalEarth;
    Vector3 origTimerScale;
    bool powerup = false;
    bool invincible = false;
    float endTime = 2f; //time for the powerup to finish if it has a duration
    float time, prevTime = 0f;
    bool flashing = true;
    bool flashActive = false;
    // Update is called once per frame
    void Start()
    {
        powerupTimer.SetActive(false);
        powerupTimerText.SetActive(false);
        anim = gameObject.GetComponent<Animation>();
        origTimerScale = powerupTimer.transform.localScale;
    }

    void Update()
    {
        if(powerup || invincible){
            powerupTimer.transform.localScale = Vector3.Lerp(origTimerScale,new Vector3(0f,1f,1f), time/endTime);
            print(powerupTimer.transform.localScale);
        }
        time += Time.deltaTime;
        if (flashActive)
        {
            flash();
        }
        if(time > endTime && powerup){
            Time.timeScale = 1f;
            powerup = false;
            powerupTimer.SetActive(false);
            powerupTimerText.SetActive(false);
        }
        if(time > endTime && invincible){
            invincible = false;
            Earth.GetComponent<Renderer>().material = Resources.Load(PlayerPrefs.GetString("planet_texture")) as Material;
            Earth.GetComponent<baseStats>().godmode = false;
            powerupTimerText.SetActive(false);
            powerupTimer.SetActive(false);
        }
    }
    public void nukePowerUp(GameObject activatorObj)
    {
        activatorObj.GetComponent<Animator>().SetTrigger("Active");
        activatorObj.GetComponent<shooting_star>().isMoving = false;
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
        endTime = 2f;
        flashActive = true;
        flashing = true;
        Time.timeScale = 0.3f;
        powerupTimerText.SetActive(true);
        powerupTimer.SetActive(true);
    }

    public void shieldPowerUp(GameObject activatorObj)
    {
        print("Shield Power Up Activated");
        Destroy(activatorObj);
        powerup = true;
        time = 0f;
        endTime = 10f;
        bool audioPlayed = false;
        Earth.GetComponent<Renderer>().material = MetalEarth;
        Earth.GetComponent<baseStats>().godmode = true;
        invincible = true;
        if (!audioPlayed)
        {
            audioPlayed = true;
            AudioManager.instance.PlaySound(ShieldEquipSound, transform.position);
        }
        powerupTimerText.SetActive(true);
        powerupTimer.SetActive(true);
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
