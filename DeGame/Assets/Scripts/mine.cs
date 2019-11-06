using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mine : MonoBehaviour
{
    // Start is called before the first frame update
    int Health;
    public Text mineHealth;
    public GameObject ParticleObject;
    ParticleSystem mineExplosionParticle;
    public AudioClip mineExplosionSound;
    bool placed;

    void Start()
    {
        mineExplosionParticle = ParticleObject.GetComponent<ParticleSystem>();
        mineExplosionParticle.Stop();
    }

    public void MinePlaced()
    {
        Health = 9;
        placed = true;
        mineHealth.text ="" + Health;
        StartCoroutine(ContinuousRotation());
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if(!placed){
            return;
        }
        print("HIT A SATELLITE");
        if (col.gameObject.tag.Equals("Enemy"))
        {
            col.gameObject.GetComponent<asteroid_float>().DestroyAsteroid();
            //Destroy(col.gameObject);
            Health -= 1;   
            mineHealth.text ="" + Health;
        }
        if(Health <= 0){
            mineExplosionParticle.Play();
            GameObject mineExplosionParticleInstance = Instantiate(ParticleObject, transform.position, transform.rotation);
            Destroy(mineExplosionParticleInstance, 3);
            Destroy(this.gameObject, 0.2f);
            bool audioPlayed = false;
            if (!audioPlayed)
            {
                audioPlayed = true;
                AudioManager.instance.PlaySound(mineExplosionSound, transform.position);
            }
        }

        //StartCoroutine(Lerpin());

    }
    IEnumerator ContinuousRotation ()
         {
             while(true){
                 transform.Rotate(0f,0f,-0.2f,Space.Self);
                 yield return new WaitForSeconds (0.01f);
             }
         }

    // Update is called once per frame
}
