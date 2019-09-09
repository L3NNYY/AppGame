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
    public AudioClip asteroidExplosion;
    private asteroid_float script;
    public GameObject pauseMenuUI;
    bool isMoving = true;
    public float speed;
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
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            CollideChecker(mousePos);
        }

    }

    public void DestroyAsteroid(){
        if (isMoving){ //stops audio playing multiple times if clicking continues once destroyed
            AudioManager.instance.PlaySound(asteroidExplosion, transform.position);
        }
        transform.Rotate(0, 0, 0, Space.Self);
        anim.SetTrigger("Active");
        isMoving = false;
        Destroy(this.gameObject, 1.0f);
    }

    void CollideChecker(Vector2 mousePoint)
    {
        if (collider.OverlapPoint(mousePoint))
        {
            DestroyAsteroid();
        }

    }

    public void movement()
    {
        float x_velocity;
        float y_velocity;
        float a = System.Math.Abs(transform.position.x);
        float b = System.Math.Abs(transform.position.y);
        float calc = (float)Math.Sqrt(a*a + b*b);
        transform.Rotate(0, 0, 1, Space.Self);
        
        if (centre.x > transform.position.x)
        {
            x_velocity = (a/calc) * speed;
        }
        else if (centre.x < transform.position.x)
        {
            x_velocity = (a / calc) *- speed;
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
            y_velocity = (b / calc) *- speed;
        }
        else
        {
            y_velocity = 0f;
        }
        transform.Translate(x_velocity * Time.deltaTime, y_velocity * Time.deltaTime, 0f, Space.World);
    }
}
 