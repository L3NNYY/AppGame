using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    GameObject gameWrapper;
    ProgressScript progress;
    ClickMultiplier multiplier;
    void Start()
    {
        gameWrapper = GameObject.Find("Game Wrapper");
        progress = gameWrapper.GetComponent<ProgressScript>();
        multiplier = gameWrapper.GetComponent<ClickMultiplier>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {

            if (Input.touches[i].phase == TouchPhase.Began)
            {
                Vector2 touchCoordinates = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                GameObject[] listOfAsteroid = GameObject.FindGameObjectsWithTag("Enemy");
                bool found = false;
                foreach (GameObject asteroid in listOfAsteroid)
                {
                    CircleCollider2D myCollider = asteroid.gameObject.GetComponent<CircleCollider2D>();
                    if (myCollider.OverlapPoint(touchCoordinates))
                    {
                        asteroid_float myScript = asteroid.GetComponent<asteroid_float>();
                        progress.addScore(5 * multiplier.getScoreMultiplier());
                        multiplier.IncrementStreak();
                        myScript.DestroyAsteroid();
                        asteroid.gameObject.tag = "Animation";
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    multiplier.resetStreakAndMultiplier();
                   // print("that missed!");

                    //reset streak
                }
                //   print(listOfAsteroid);
                //    print(i + " " + Input.touches[i].phase + Camera.main.ScreenToWorldPoint(Input.touches[i].position));
                //if (OverlapPoint(Camera.main.ScreenToWorldPoint(Input.touches[i].position)))
                // {
                // progress.addScore(points * multiplier.getScoreMultiplier());
                //multiplier.IncrementStreak();
                //multiplier.hitSetter();

                // }
            }
            /*         Plan of reconstruction:
                    When button is clicked, get list of all asteroid objects
             Check if any hitboxes match position of finger
             If so set found = true and break
             If found == true incremeant streak and destroy object
             Else reset streak
             */
        }
    }
}

