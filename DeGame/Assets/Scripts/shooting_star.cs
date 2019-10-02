using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_star : MonoBehaviour
{

    //Animator anim;
    Vector2 mousePos;
    CircleCollider2D collider;
    ClickController click;
    powerups powerups;
    System.Random random = new System.Random();

    public RuntimeAnimatorController slowTimeAnim;
    public RuntimeAnimatorController nukeAnim;
    public bool isMoving = true;
    private int type;
    private Vector2 screenBounds;
    //type 1 = nuke
    //type 2 = time control
    Animator animator;

    public Vector2 destination;
    float speed = 6f;
    public string startingPos;

    void Start()
    {
        click = gameObject.AddComponent<ClickController>();
        spawnCords();
        collider = gameObject.GetComponent<CircleCollider2D>();
        powerups = GameObject.Find("Game Wrapper").GetComponent<powerups>();
        animator = this.GetComponent<Animator>();
        int randomizer = random.Next(1, 3);
        //renderer.sprite = 
        switch (randomizer)
        {
            case 1:
                type = 1;
                animator.runtimeAnimatorController = nukeAnim;
                break;
            case 2:
                type = 2;
                animator.runtimeAnimatorController = slowTimeAnim;
                break;
        }
    }



    void Update()
    {
        onClick();
        moving();
        if (transform.position.x > 12.5f && startingPos.Equals("left") || transform.position.x < -12.5f && startingPos.Equals("right")) //destroyed once out of map
        {
            Destroy(this.gameObject);
        }

    }
    void spawnCords()
    {
        SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        int rand = random.Next(1, 3);
        if (rand == 1)
        {
            transform.position = new Vector2(-12.64f, UnityEngine.Random.Range((-screenBounds.y + (float)0.2), (screenBounds.y - (float)0.2)));
            destination = new Vector2(+12.64f, UnityEngine.Random.Range((-screenBounds.y + (float)0.2), (screenBounds.y - (float)0.2)));
            startingPos = "left";
        }
        else
        {
            transform.position = new Vector2(+12.64f, UnityEngine.Random.Range((-screenBounds.y + (float)0.2), (screenBounds.y - (float)0.2)));
            destination = new Vector2(-12.64f, UnityEngine.Random.Range((-screenBounds.y + (float)0.2), (screenBounds.y - (float)0.2)));
            startingPos = "right";
        }
        rotate();

    }
    void onClick()
    {
        if (click.collideChecker(collider, 30))
        {
            if (this.type == 1)
            {
                powerups.nukePowerUp(this.gameObject);
            }
            else if (this.type == 2)
            {
                powerups.slowDownTime(this.gameObject);
            }
        }
    }
    void moving()
    {
        if (!isMoving)
        {
            return;
        }
        float x_velocity;
        float y_velocity;
        float a = System.Math.Abs(this.transform.position.x - destination.x);
        float b = System.Math.Abs(this.transform.position.y - destination.y);
        float calc = (float)Math.Sqrt(a * a + b * b);
        if (destination.x> transform.position.x)
        {
            x_velocity = (a / calc) * speed;
        }
        else if (destination.x < transform.position.x)
        {
            x_velocity = (a / calc) * -speed;
        }
        else
        {
            x_velocity = 0f;
        }

        if (destination.y > transform.position.y)
        {
            y_velocity = (b / calc) * speed;
        }
        else if (destination.y < transform.position.y)
        {
            y_velocity = (b / calc) * -speed;
        }
        else
        {
            y_velocity = 0f;
        }
        transform.Translate(x_velocity * Time.deltaTime, y_velocity * Time.deltaTime, 0f, Space.World);

    }
    void rotate()
    {
        float a = System.Math.Abs(this.transform.position.x - destination.x);
        float b = System.Math.Abs(this.transform.position.y - destination.y);
        float calc = (float)Math.Sqrt(a * a + b * b);
        SpriteRenderer render = this.GetComponent<SpriteRenderer>();

        Transform thisTransform = this.GetComponent<Transform>();
        float num1 = (float)Math.Asin((Math.Sin(90) / calc) * b);
        float degrees = ((180 / (float)Math.PI) * num1);
        if (this.transform.position.y > destination.y && this.transform.position.x < 0)
        {
            thisTransform.Rotate(0f, 0f, -degrees, Space.Self);
        }
        else if (this.transform.position.y < destination.y && this.transform.position.x < 0)
        {
            thisTransform.Rotate(0f, 0f, degrees, Space.Self);
        }
        else if (this.transform.position.y > destination.y && this.transform.position.x > 0)
        {
            render.flipY = true;
            thisTransform.Rotate(0f, 0f, degrees + 180, Space.Self);
        }
        else if (this.transform.position.y < destination.y && this.transform.position.x > 0)
        {
            render.flipY = true;
            thisTransform.Rotate(0f, 0f, -degrees + 180, Space.Self);
        }

    }
}
