using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visual_increment : MonoBehaviour
{
    Vector2 origPos; //original position of the object
    bool movingUp = true;
    int timePassed;
    void Start()
    {
        timePassed = 0;
    }

    // Update is called once per frame
    public void showIncrement(Vector2 position)
    {
        transform.position = position;
        
        gameObject.SetActive(true);
        StartCoroutine(incrementUp());
    }
    IEnumerator incrementUp()
    {
        while (movingUp)
        {
            transform.Translate(0f, 0.01f, 0f, Space.World);
            timePassed++;
            gameObject.GetComponent<Text>().color = new Vector4(gameObject.GetComponent<Text>().color.r,gameObject.GetComponent<Text>().color.g,gameObject.GetComponent<Text>().color.b,1f - ((float)timePassed/150));
            if(timePassed >= 100){
                Destroy(this.gameObject, 0.7f);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
