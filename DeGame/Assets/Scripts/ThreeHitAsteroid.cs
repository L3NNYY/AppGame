using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeHitAsteroid : asteroid_float
{
    // Start is called before the first frame update
    int counter = 0;
    void Start()
    {
        
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            movement();
        }
        if (click.collideChecker(collider, 5))
        {
            if (counter == 2)
            {
                DestroyAsteroid();
            }
            else
            {
                counter += 1;
            }
        }

    }
}
