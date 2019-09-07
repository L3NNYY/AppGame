using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour
{
    public Text scoreText;
    public int gameScore = 0;
    int fullScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0f){
            fullScore += 1;
            gameScore = fullScore/10;
            scoreText.text = "" + gameScore;
        }
    }
}
