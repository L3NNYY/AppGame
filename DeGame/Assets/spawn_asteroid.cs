using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawn_asteroid : MonoBehaviour
{
    public GameObject asteroid;
    readonly float rate = 0.5f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnMultiple());
    }

    // Update is called once per frame
    private void spawnAsteroid()
    {
        Vector2 spawn = new Vector2(0, 0);
        GameObject ast = Instantiate(asteroid) as GameObject;
        System.Random random = new System.Random();
        int randomNumber = random.Next(1, 5);
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
        ast.transform.position = spawn;
    }





    IEnumerator SpawnMultiple()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            spawnAsteroid();
        }
    }
}


