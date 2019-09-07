using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    public void setSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
