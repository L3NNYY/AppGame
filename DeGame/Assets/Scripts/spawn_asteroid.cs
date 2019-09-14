using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawn_asteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject Asteroids; // Parent to store all asteroid prefabs
    float asteroidSpeed = 1.25f;
    float rate = 2f;
    float minimumScale = 0.03f;
    float maximumScale = 0.07f;
    private Vector2 screenBounds;
    int level = 1;
    int oldScore = 0;
    System.Random random = new System.Random();
    private readonly Color[] colors = { new Color(0, 0, 1, 1), new Color(0, 1, 0, 1), new Color(1, 0, 0, 1), new Color(203, 97, 136, 255), new Color(72, 1, 0, 255) }; //aray with different colours
    //public Color[] colors = { new Color(), new Color(), new Color(), new Color(), new Color()};
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnMultiple());
    }

    private void spawnAsteroid()
    {
        SpriteRenderer renderer;
        int randomNumber = random.Next(0, 5);
        GameObject ast = Instantiate(asteroidPrefab) as GameObject;
        renderer = ast.GetComponent<SpriteRenderer>();
        renderer.color =  colors[randomNumber];


        Vector2 spawn = new Vector2(0, 0);
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


