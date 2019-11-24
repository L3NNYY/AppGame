using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeHitAsteroid : asteroid_float
{
    // Start is called before the first frame update
    public int counter = 0;
    public Sprite nohit;
    public Sprite hit1;
    public Sprite hit2;
    Sprite[] textures;
    public SpriteRenderer asteroid;

    protected override void Start()
    {
        textures = new Sprite[] { nohit, hit1, hit2 };
        base.Start();
        anim.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isMoving)
        {
            movement();
        }

    }
    public override void hit()
    {
        if (counter == 2)
        {
            this.gameObject.tag = "Animation";
            DestroyAsteroid();
        }
        else
        {
            counter += 1;
            asteroid.sprite = textures[counter];

        }
    }

}
