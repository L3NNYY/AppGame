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
    private int type;
    //type 1 = nuke
    //type 2 = time control
    Animator animator;

    void Start()
    {
        click = gameObject.AddComponent<ClickController>();
        float y_loc = Random.Range(-3.0f, 3.0f);
        transform.position = new Vector2(-12.64f, y_loc);
        //anim = gameObject.GetComponent<Animator>();
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




        // Update is called once per frame
        void Update()
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

            transform.Translate(4f * Time.deltaTime, 0, 0f, Space.World);

            if (transform.position.x > 22f) //destroyed once out of map
            {
                Destroy(this.gameObject);
            }
        }
    }
