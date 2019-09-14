using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    Vector2 mousePos;
    GameObject gameWrapper;
    ProgressScript progress;
    void Start(){
        gameWrapper = GameObject.Find("Game Wrapper");
        progress = gameWrapper.GetComponent<ProgressScript>();
    }
    public bool collideChecker(CircleCollider2D objectCollider, int points){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            if (objectCollider.OverlapPoint(mousePos)){
                progress.addScore(points);
                return true;
            }
        }
        return false;
    }
}
