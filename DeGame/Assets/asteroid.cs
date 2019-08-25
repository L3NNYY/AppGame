using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Collider2D player_base;
    private CircleCollider2D circle;
    private asteroid_float scriptA;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        circle = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
