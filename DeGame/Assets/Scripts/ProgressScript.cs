using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour
{
    public Text scoreText;
    public int secondsPassed = 0;
    float secondsScore = 0;
    public int gameScore;
    float textPopAnim = 1f;
    Vector3 originalScoreTextSize;
    float time = 0f;
    powerups powerups;
    // Start is called before the first frame update
    void Start()
    {
        originalScoreTextSize = scoreText.transform.localScale;
        powerups = gameObject.GetComponent<powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0f){
            secondsScore += Time.deltaTime;
            secondsPassed = (int)secondsScore;
            scoreText.text = "" + gameScore;
            PopText();
        }

        if (Input.GetKeyDown(KeyCode.P)){ //Power up activation
            powerups.nukePowerUp(null);
        }
    }

    public void addScore(int value){
        gameScore += value;
        textPopAnim = 0f;
    }
    void PopText(){
        time += Time.deltaTime;
        if(time >= 0.05f){
            textPopAnim += 0.05f;
        }
        scoreText.color = Color.Lerp(Color.red,Color.white,textPopAnim);
        scoreText.transform.localScale = Vector3.Lerp(new Vector3(2f,2f,1.46f),originalScoreTextSize, textPopAnim);
    }
}
