using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawn_asteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject threeHitAsteroidPrefab;
    public GameObject wavyAsteroidPrefab;
    public GameObject largeAsteroidPrefab;
    public GameObject Asteroids; // Parent to store all asteroid prefabs
    float asteroidSpeed = 1.25f;
    float rate = 2f;
    float minimumScale = 0.03f;
    float maximumScale = 0.07f;
    private Vector2 screenBounds;
    int level = 1;
    int oldScore = 0;
    System.Random random = new System.Random();
    public Sprite[] spriteList;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5f));
        StartCoroutine(SpawnMultiple());
    }

    private void spawnAsteroid()
    {
        int chooseType = random.Next(1, 11);
        int randomNumber;
        GameObject ast;
        if (chooseType == 1)
        {

            ast = Instantiate(threeHitAsteroidPrefab) as GameObject;
            minimumScale = 0.06f;
            maximumScale = 0.1f;
        }
        else if (chooseType == 2 || chooseType == 3)
        {

            ast = Instantiate(wavyAsteroidPrefab) as GameObject;
            minimumScale = 0.01f;
            maximumScale = 0.03f;
        }
        else if (chooseType == 4)
        {

            ast = Instantiate(largeAsteroidPrefab) as GameObject;
            minimumScale = 0.06f;
            maximumScale = 0.07f;
        }
        else
        {
            minimumScale = 0.03f;
            maximumScale = 0.07f;
            randomNumber = random.Next(0, 5);
            asteroidPrefab.GetComponent<SpriteRenderer>().sprite = spriteList[randomNumber];
            ast = Instantiate(asteroidPrefab) as GameObject;
        }


            Vector2 spawn = new Vector2(0, 0);
            ast.transform.parent = Asteroids.transform;
            asteroid_float astScript = ast.GetComponent<asteroid_float>();
            ProgressScript prog = gameObject.GetComponent<ProgressScript>(); //Gets the game score from progress script
                                                                             //TODO: this area will most likely simplify upon a major revamp, getting components together
                                                                             //such as spawn_asteroids shouldn't be in camera, but in Game Wrapper - This can happen later
            if(chooseType == 2 || chooseType == 3 ){
                astScript.wavy = true;
            }
            if (oldScore + 20 < prog.secondsPassed)
            {
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


