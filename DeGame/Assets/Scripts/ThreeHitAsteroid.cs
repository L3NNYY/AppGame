using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeHitAsteroid : asteroid_float
{
    // Start is called before the first frame update
    int counter = 0;
    protected override void Start()
    {
        
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isMoving)
        {
            movement();
        }
        if (this.gameObject.tag.Equals("Enemy"))
        {
            if (click.collideChecker(collider, 5))
            {
                if (counter == 2)
                {
                    this.gameObject.tag = "Animation";
                    DestroyAsteroid();
                }
                else
                {
                    counter += 1;
                }
            }
        }

    }
}
