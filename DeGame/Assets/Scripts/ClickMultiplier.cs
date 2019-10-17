using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMultiplier : MonoBehaviour
{
    private bool hit;

    int streak;
    int scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {

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
    public void BackgroundClick() //button click function
    {
        
        if (Time.timeScale != 0f)
        {
            if (hit == true)
            {
               // print("hit!");
                hit = false;
            }
            else
            {
               // print("you missed!");
                resetStreakAndMultiplier();
            }
        }
    }
    public void resetStreakAndMultiplier()
    {
        streak = 0;
        scoreMultiplier = 1;
    }
    public void hitSetter()
    {
        hit = true;
    }
}
