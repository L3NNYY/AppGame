using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_star : MonoBehaviour
{
    Animator anim;
    Vector2 mousePos;
    CircleCollider2D collider;
    ClickController click;
    powerups powerups;
    // Start is called before the first frame update
    void Start()
    {
        click = gameObject.AddComponent<ClickController>();
        float y_loc = Random.Range(-3.0f, 3.0f);
        transform.position = new Vector2(-12.64f, y_loc);
        anim = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        powerups = GameObject.Find("Game Wrapper").GetComponent<powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        if (click.collideChecker(collider, 30))
        {
            powerups.nukePowerUp(this.gameObject);
        }
        
        transform.Translate(4f * Time.deltaTime, 0, 0f, Space.World);

        if (transform.position.x > 22f) //destroyed once out of map
        { 
            Destroy(this.gameObject);
        }
    }
}
