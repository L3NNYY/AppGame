using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    public AudioClip asteroidExplosion;
    // Update is called once per frame
    public void nukePowerUp(){
        print("nuke activated");
        bool audioPlayed = false;
        foreach (var asteroid in FindObjectsOfType(typeof(GameObject)) as GameObject[]) {
            if(asteroid.name == "asteroid(Clone)"){
                if(!audioPlayed){
                    audioPlayed = true;
                    AudioManager.instance.PlaySound(asteroidExplosion, transform.position);
                }
             asteroid_float ast = asteroid.GetComponent<asteroid_float>();
             ast.DestroyAsteroid();
            }
         }
    }
}
