using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour
{
    public Text scoreText;
    public int gameScore = 0;
    float fullScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0f){
            fullScore += Time.deltaTime;
            gameScore = (int) fullScore * 3;
            scoreText.text = "" + gameScore;
        }
    }
}
