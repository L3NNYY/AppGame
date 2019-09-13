using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Planet"))
        {
            HealthBarScript.health -= 5;
        }
        //print("Noo, you've been hit!");
        //print("You're on: " + current_health + " health points!");
    }
}
