﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class asteroid_float : MonoBehaviour
{

    Vector2 centre;
    protected Animator anim;
    protected CircleCollider2D collider;
    protected ClickController click;
    public AudioClip asteroidExplosion;
    protected bool isMoving = true;
    public float speed;
    // Start is called before the first frame update
    public void Start()
    {
        click = gameObject.AddComponent<ClickController>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        centre = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    public void Update()
    {
        if (isMoving)
        {
            movement();
        }
        if (this.gameObject.tag.Equals("Enemy"))
        {
            if (click.collideChecker(collider, 5))
            {
                this.gameObject.tag = "Animation";
                DestroyAsteroid();
            }
            
        }

    }

    public void DestroyAsteroid()
    {
        if (isMoving)
        { //stops audio playing multiple times if clicking continues once destroyed
            AudioManager.instance.PlaySound(asteroidExplosion, transform.position);
        }
        transform.Rotate(0, 0, 0, Space.Self);
        anim.SetTrigger("Active");
        isMoving = false;
        Destroy(this.gameObject, 1.0f);
    }


    public void movement()
    {
        float x_velocity;
        float y_velocity;
        float a = System.Math.Abs(transform.position.x);
        float b = System.Math.Abs(transform.position.y);
        float calc = (float)Math.Sqrt(a * a + b * b);
        if (Time.timeScale != 0f)
        {
            transform.Rotate(0, 0, 1, Space.Self);
        }
        if (centre.x > transform.position.x)
        {
            x_velocity = (a / calc) * speed;
        }
        else if (centre.x < transform.position.x)
        {
            x_velocity = (a / calc) * -speed;
        }
        else
        {
            x_velocity = 0f;
        }





        if (centre.y > transform.position.y)
        {
            y_velocity = (b / calc) * speed;
        }
        else if (centre.y < transform.position.y)
        {
            y_velocity = (b / calc) * -speed;
        }
        else
        {
            y_velocity = 0f;
        }
        transform.Translate(x_velocity * Time.deltaTime, y_velocity * Time.deltaTime, 0f, Space.World);
    }
}
