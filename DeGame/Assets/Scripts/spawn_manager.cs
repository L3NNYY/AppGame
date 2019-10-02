using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public GameObject shootingstar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStar());
    }

    private void spawnPowerUp(){
        GameObject star = Instantiate(shootingstar) as GameObject;
    }

    IEnumerator SpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            spawnPowerUp();
        }
    }
}
