using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 mousePos;
    public bool collideChecker(CircleCollider2D objectCollider){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            if (objectCollider.OverlapPoint(mousePos)){
                return true;
            }
        }
        return false;
    }
}
