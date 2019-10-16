using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMultiplier : MonoBehaviour
{
    Vector2 mousePos;
    GameObject gameWrapper;
    ProgressScript progress;
    GameObject background;
    BoxCollider2D backgroundCollider;

    int streak;
    int scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        gameWrapper = GameObject.Find("Game Wrapper");
        progress = gameWrapper.GetComponent<ProgressScript>();
        background = GameObject.Find("Background");
        backgroundCollider = background.GetComponent<BoxCollider2D>();
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private bool CollideCheckerBox(BoxCollider2D collider)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            if (collider.OverlapPoint(mousePos))
            {
                return true;
            }
        }
        return false;
    }
    public void IncrementStreak()
    {
        streak += 1;
        handleStreak();
    }
    
    private void handleStreak()
    {
            if (streak % 5 == 0)
            {
                scoreMultiplier += 1;
                print(scoreMultiplier);
            }

    }
    public int getScoreMultiplier()
    {
        return scoreMultiplier;
    }

}
