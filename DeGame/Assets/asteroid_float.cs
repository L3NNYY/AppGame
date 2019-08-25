using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class asteroid_float : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 centre;
    Animator anim;
    CircleCollider2D collider;
    private asteroid_float script;
    bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        centre = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // print(centre);
        //print(mousePos);
        if (isMoving)
        {
            movement();
        }
        if (Input.GetMouseButtonDown(0))
        {
            CollideChecker(mousePos);
        }

    }


    void CollideChecker(Vector2 mousePoint)
    {
        if (collider.OverlapPoint(mousePoint))
        {
            anim.SetTrigger("Active");
            isMoving = false;
            Destroy(this.gameObject, 1.0f);
        }

    }

    public void movement()
    {
        float x_velocity;
        float y_velocity;
        if (centre.x > transform.position.x)
        {
            x_velocity = 2f;
        }
        else if (centre.x < transform.position.x)
        {
            x_velocity = -2f;
        }
        else
        {
            x_velocity = 0f;
        }

        if (centre.y > transform.position.y)
        {
            y_velocity = 2f;
        }
        else if (centre.y < transform.position.y)
        {
            y_velocity = -2f;
        }
        else
        {
            y_velocity = 0f;
        }
        transform.Translate(x_velocity * Time.deltaTime, y_velocity * Time.deltaTime, 0f);
    }
}
 