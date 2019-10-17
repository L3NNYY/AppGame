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
    public bool collideChecker(CircleCollider2D objectCollider, int points)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            if (objectCollider.OverlapPoint(mousePos))
            {
                progress.addScore(points * multiplier.getScoreMultiplier());
                multiplier.IncrementStreak();
                multiplier.hitSetter();
                return true;
            }
        }
        return false;
    }
}
