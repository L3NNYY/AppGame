using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawn_asteroid : MonoBehaviour
{
    public GameObject asteroid1, asteroid2, asteroid3, asteroid4, asteroid5;
    public GameObject Asteroids; // Parent to store all asteroid prefabs
    GameObject asteroid;
    float asteroidSpeed = 1.25f;
    float rate = 2f;
    float minimumScale = 0.03f;
    float maximumScale = 0.07f;
    private Vector2 screenBounds;
    int level = 1;
    int oldScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnMultiple());
    }

    // Update is called once per frame
    private void spawnAsteroid()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(1, 6);
        switch (randomNumber)
        {
            case 1:
                asteroid = asteroid1;
                break;
            case 2:
                asteroid = asteroid2;
                break;
            case 3:
                asteroid = asteroid3;
                break;
            case 4:
                asteroid = asteroid4;
                break;
            case 5:
                asteroid = asteroid5;
                break;
        }
        Vector2 spawn = new Vector2(0, 0);
        GameObject ast = Instantiate(asteroid) as GameObject;
        ast.transform.parent = Asteroids.transform;
        asteroid_float astScript = ast.GetComponent<asteroid_float>();
        ProgressScript prog = gameObject.GetComponent<ProgressScript>(); //Gets the game score from progress script
        //TODO: this area will most likely simplify upon a major revamp, getting components together
        //such as spawn_asteroids shouldn't be in camera, but in Game Wrapper - This can happen later
        if(oldScore + 20 < prog.secondsPassed){
            oldScore = prog.secondsPassed;
            level += 1;
            asteroidSpeed += 0.35f * level;
            rate = rate / level;
            print("Level: " + level);
        } 
        randomNumber = random.Next(1, 5);
        if (randomNumber == 1)
        {
            spawn = new Vector2(screenBounds.x*2, UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if (randomNumber == 2)
        {
            spawn = new Vector2(-screenBounds.x*2, UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if (randomNumber == 3)
        {
            spawn = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y*2);
        }
        else if (randomNumber == 4)
        {
            spawn = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y*2);
        }
        astScript.speed = asteroidSpeed;
        ast.transform.position = spawn;
        float size = UnityEngine.Random.Range(minimumScale, maximumScale);
        ast.transform.localScale += new Vector3(size, size);
    }





    IEnumerator SpawnMultiple()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
            spawnAsteroid();
        }
    }
}


