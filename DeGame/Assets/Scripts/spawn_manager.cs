using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public GameObject shootingstar;
    public GameObject Asteroids;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStar());
        Asteroids = GameObject.Find("Asteroids");
    }

    private void spawnPowerUp(){
        GameObject star = Instantiate(shootingstar) as GameObject;
        star.transform.parent = Asteroids.transform;
    }

    IEnumerator SpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(14);//default 14
            spawnPowerUp();
        }
    }
}
