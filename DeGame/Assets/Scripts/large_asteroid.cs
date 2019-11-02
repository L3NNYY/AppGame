using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_asteroid : asteroid_float
{
    // Start is called before the first frame update
    int counter = 5;
    GameObject ast;
    SpriteRenderer sprite;
    public GameObject asteroidPrefab;
    protected override void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        this.speed = 0.4f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(this.speed > 0.4f){
            this.speed = 0.3f;
        }
        if (isMoving)
        {
            movement();
        }
        if (this.gameObject.tag.Equals("Enemy"))
        {
            if (click.collideChecker(collider, 5))
            {
                StartSpawn();
            }
        }
    }

    public void StartSpawn()
    {
        speed = 0.1f;
        StartCoroutine(SpawnAsteroids(counter));
    }
    IEnumerator SpawnAsteroids(int coutner)
    {
        for (int i = 0; i < counter; i++)
        {
            sprite.color = Color.Lerp(sprite.color, Color.red, (float)i / 10);
            ast = Instantiate(asteroidPrefab) as GameObject;
            ast.GetComponent<asteroid_float>().speed = 1f;
            ast.transform.position = new Vector2(transform.position.x + UnityEngine.Random.Range(-1f, 1f), transform.position.y + UnityEngine.Random.Range(-1f, 1f));
            ast.transform.localScale = new Vector2(0.05f, 0.05f);
            yield return new WaitForSeconds(0.2f);
        }
        DestroyAsteroid();
    }
}
