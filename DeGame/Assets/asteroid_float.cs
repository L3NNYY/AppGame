using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class asteroid_float : MonoBehaviour
{
    Vector3 mousepos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        mousepos = Input.mousePosition;
        Vector3 mousepoint = Camera.main.ScreenToWorldPoint(mousepos);
        float x_velocity;
        float y_velocity;
        print (mousepoint);
        if(mousepoint.x > transform.position.x){
            x_velocity = 2f;
        }
        else if(mousepoint.x < transform.position.x){
             x_velocity = -2f;
        }
        else{
            x_velocity = 0f;
        }

        if(mousepoint.y > transform.position.y){
            y_velocity = 2f;
        }
        else if(mousepoint.y < transform.position.y){
            y_velocity = -2f;
        }
        else{
            y_velocity = 0f;
        }
        transform.Translate(x_velocity*Time.deltaTime,y_velocity*Time.deltaTime,0f);
    }
}
