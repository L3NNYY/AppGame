using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollisionChecker : MonoBehaviour
{
    GameObject gameWrapper;
    ProgressScript progress;
    ClickMultiplier multiplier;
    private mine_spawn mine_spawn_script;
    public GameObject ButtonGameObject;
    public GameObject[] Buttons;
    void Start()
    {

        mine_spawn_script = GameObject.Find("MineButton").GetComponent<mine_spawn>();
        Buttons = GameObject.FindGameObjectsWithTag("Button");
        gameWrapper = GameObject.Find("Game Wrapper");
        progress = gameWrapper.GetComponent<ProgressScript>();
        multiplier = gameWrapper.GetComponent<ClickMultiplier>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!mine_spawn_script.checkIfMineDragged())
        {

            mouseControl();

            //touchControl();//use touchControl for touch displays
        }


    }
    public void touchControl()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {

            if (Input.touches[i].phase == TouchPhase.Began && checkIfButtonsHit() == false && Time.timeScale != 0f)
            {
                Vector2 touchCoordinates = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                GameObject[] listOfAsteroid = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUP");
                bool found = false;
                print(i + " " + Input.touches[i].phase + Camera.main.ScreenToWorldPoint(Input.touches[i].position));
                foreach (GameObject asteroid in listOfAsteroid)
                {
                    CircleCollider2D myCollider = asteroid.gameObject.GetComponent<CircleCollider2D>();
                    if (myCollider.OverlapPoint(touchCoordinates))
                    {
                        // was originally going to select asteroid type based on their script type, but wavy asteroid and regular
                        // asteroids are using the same script
                        if (asteroid.name.Equals("asteroid(Clone)"))
                        {
                            asteroid_float myScript = asteroid.GetComponent<asteroid_float>();
                            myScript.hit();
                            found = true;
                        }
                        else if (asteroid.name.Equals("threeHitAsteroid(Clone)"))
                        {
                            ThreeHitAsteroid threeHitAst = asteroid.GetComponent<ThreeHitAsteroid>();
                            threeHitAst.hit();
                            found = true;
                        }
                        else if (asteroid.name.Equals("large asteroid(Clone)"))
                        {
                            large_asteroid la = asteroid.GetComponent<large_asteroid>();
                            la.StartSpawn();
                            found = true;
                        }
                        else if (asteroid.name.Equals("wavy_asteroid(Clone)"))
                        {
                            asteroid_float myScript = asteroid.GetComponent<asteroid_float>();
                            myScript.hit();
                            found = true;
                        }


                        if (found == true)
                        {
                            progress.addScore(5 * multiplier.getScoreMultiplier());
                            multiplier.IncrementStreak();
                            break;
                        }
                    }
                }
                foreach (GameObject powerUp in powerUps)
                {
                    CircleCollider2D myCollider = powerUp.gameObject.GetComponent<CircleCollider2D>();
                    if (myCollider.OverlapPoint(touchCoordinates))
                    {
                        shooting_star script = powerUp.GetComponent<shooting_star>();
                        script.onClick();
                        progress.addScore(5 * multiplier.getScoreMultiplier());
                        multiplier.IncrementStreak();
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    multiplier.resetStreakAndMultiplier();

                }
            }

        }

    }
    public void mouseControl()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && checkIfButtonsHit() == false)
        {
            GameObject[] listOfAsteroid = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUP");
            bool found = false;
            foreach (GameObject asteroid in listOfAsteroid)
            {
                CircleCollider2D myCollider = asteroid.gameObject.GetComponent<CircleCollider2D>();
                if (myCollider.OverlapPoint(mousePos))
                {
                    // was originally going to select asteroid type based on their script type, but wavy asteroid and regular
                    // asteroids are using the same script
                    if (asteroid.name.Equals("asteroid(Clone)"))
                    {
                        asteroid_float myScript = asteroid.GetComponent<asteroid_float>();
                        myScript.hit();
                        found = true;
                    }
                    else if (asteroid.name.Equals("threeHitAsteroid(Clone)"))
                    {
                        ThreeHitAsteroid threeHitAst = asteroid.GetComponent<ThreeHitAsteroid>();
                        threeHitAst.hit();
                        found = true;
                    }
                    else if (asteroid.name.Equals("large asteroid(Clone)"))
                    {
                        large_asteroid la = asteroid.GetComponent<large_asteroid>();
                        la.StartSpawn();
                        found = true;
                    }
                    else if (asteroid.name.Equals("wavy_asteroid(Clone)"))
                    {
                        asteroid_float myScript = asteroid.GetComponent<asteroid_float>();
                        myScript.hit();
                        found = true;
                    }


                    if (found == true)
                    {
                        progress.addScore(5 * multiplier.getScoreMultiplier());
                        multiplier.IncrementStreak();
                        break;
                    }
                }
            }
            foreach (GameObject powerUp in powerUps)
            {
                CircleCollider2D myCollider = powerUp.gameObject.GetComponent<CircleCollider2D>();
                if (myCollider.OverlapPoint(mousePos))
                {
                    shooting_star script = powerUp.GetComponent<shooting_star>();
                    script.onClick();
                    progress.addScore(5 * multiplier.getScoreMultiplier());
                    multiplier.IncrementStreak();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                multiplier.resetStreakAndMultiplier();
            }
        }
    }
    public bool checkIfButtonsHit()
    {
        foreach (GameObject button in Buttons)
        {
            if (EventSystem.current.currentSelectedGameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}

