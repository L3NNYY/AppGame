using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    //public Image health;
    private Image health;
    private Image[] images;
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        health = images[2];
        foreach (Image localimage in images){
            images = null;
        }

    }

    // Update is called once per frame
    public void setSize(float setFillAmount)
    {
        bar.localScale = new Vector2(size, 1f);

    }
}
