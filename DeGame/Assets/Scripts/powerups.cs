using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    public AudioClip asteroidExplosion;
    bool nukeactive = false;
    bool flashing = true;
    // Update is called once per frame
    void Update()
    {
        if (nukeactive)
        {
            flash();
        }
    }
    public void nukePowerUp()
    {
        nukeactive = true;
        flashing = true;
        print("nuke activated");
        bool audioPlayed = false;
        foreach (var asteroid in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (asteroid.name == "asteroid 1(Clone)" || asteroid.name == "asteroid 2(Clone)" ||
             asteroid.name == "asteroid 3(Clone)" || asteroid.name == "asteroid 4(Clone)" ||
              asteroid.name == "asteroid 5(Clone)")
            {
                if (!audioPlayed)
                {
                    audioPlayed = true;
                    AudioManager.instance.PlaySound(asteroidExplosion, transform.position);
                }
                asteroid_float ast = asteroid.GetComponent<asteroid_float>();
                ast.DestroyAsteroid();
            }
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
                nukeactive = false;
            }
        }

    }
}
