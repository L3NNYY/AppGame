using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour
{
    public Text scoreText;
    public int gameScore = 0;
    float fullScore = 0;
    public int testMultiplier = 1;
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
            fullScore += Time.deltaTime;
            gameScore = (int) fullScore * 3 * testMultiplier;
            scoreText.text = "" + gameScore;
        }

        if (Input.GetKeyDown(KeyCode.P)){ //Power up activation
            powerups.nukePowerUp(null);
        }
    }
}
