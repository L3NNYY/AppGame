using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour
{
    public Text scoreText;
    public int secondsPassed = 0;
    float secondsScore = 0;
    public int testMultiplier = 1;

    public int gameScore;
    powerups powerups;
    // Start is called before the first frame update
    void Start()
    {
        powerups = gameObject.GetComponent<powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0f){
            secondsScore += Time.deltaTime;
            secondsPassed = (int) secondsScore * testMultiplier;
            scoreText.text = "" + gameScore;
        }

        if (Input.GetKeyDown(KeyCode.P)){ //Power up activation
            powerups.nukePowerUp(null);
        }
    }

    public void addScore(int value){
        gameScore += value;
    }
}
