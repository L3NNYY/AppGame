using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_star : MonoBehaviour
{
    Animator anim;
    Vector2 mousePos;
    CircleCollider2D collider;
    powerups powerups;
    // Start is called before the first frame update
    void Start()
    {
        float y_loc = Random.Range(-3.0f,3.0f);
        transform.position = new Vector2(-12.64f,y_loc);
        anim = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        powerups = GameObject.Find("Game Wrapper").GetComponent<powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider.OverlapPoint(mousePos))
            {
                powerups.nukePowerUp();
                Destroy(this.gameObject);
            }
        }
        transform.Translate(4f * Time.deltaTime, 0, 0f, Space.World);

        if(transform.position.x > 22f){ //destroyed once out of map
            Destroy(this.gameObject);
        }
    }
}
