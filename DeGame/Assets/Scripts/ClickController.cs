using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    Vector2 mousePos;
    GameObject gameWrapper;
    ProgressScript progress;
    ClickMultiplier multiplier;

    void Start()
    {
        gameWrapper = GameObject.Find("Game Wrapper");
        progress = gameWrapper.GetComponent<ProgressScript>();
        multiplier = gameWrapper.GetComponent<ClickMultiplier>();


    }
    public bool collideCheckerDont(CircleCollider2D objectCollider, int points)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            if (objectCollider.OverlapPoint(mousePos))
            {
                progress.addScore(points * multiplier.getScoreMultiplier());
                multiplier.IncrementStreak();
            //    multiplier.hitSetter();
                return true;
            }
        }
        return false;
    }

    public bool collideChecker(CircleCollider2D objectCollider, int points)
    {
        return false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began)
            {

                print(i + " " + Input.touches[i].phase + Camera.main.ScreenToWorldPoint(Input.touches[i].position));
                if (objectCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.touches[i].position)))
                {
                    progress.addScore(points * multiplier.getScoreMultiplier());
                    multiplier.IncrementStreak();
                //    multiplier.hitSetter();
                    return true;

                }
            }
        }
        return false;
    }
    public bool collideCheckerTest2(CircleCollider2D objectCollider, int points)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            print(touchPos);

        }
        return false;
    }
}
