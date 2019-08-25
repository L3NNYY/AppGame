using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class asteroid_float : MonoBehaviour
{
    Vector3 mousePos;
    Animator anim;
    CircleCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        mousePos = Input.mousePosition;
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(mousePos);
        float x_velocity;
        float y_velocity;
        if(mousePoint.x > transform.position.x){
            x_velocity = 2f;
        }
        else if(mousePoint.x < transform.position.x){
             x_velocity = -2f;
        }
        else{
            x_velocity = 0f;
        }

        if(mousePoint.y > transform.position.y){
            y_velocity = 2f;
        }
        else if(mousePoint.y < transform.position.y){
            y_velocity = -2f;
        }
        else{
            y_velocity = 0f;
        }
        transform.Translate(x_velocity*Time.deltaTime,y_velocity*Time.deltaTime,0f);
        if(Input.GetMouseButtonDown(0)){
            CollideChecker(mousePoint);
        }
        
    }

    void CollideChecker(Vector3 mousePoint){
        if(collider.OverlapPoint(mousePoint)){
            anim.SetTrigger("Active");
        }

    }
}
