using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class mine_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Text btnText;
    public Sprite btnlocked;
    public Button btnImage;
    public Sprite btnunlocked;
    GameObject mine;
    bool minePlacement = false;
    public GameObject minePrefab;
    public AudioSource audio;
    static float lastClick = -999f;
    float timeElapsed, secondPassed = 0f;
    bool unavailable = false;
    int mineTimeout = 10;
    int minesLeft;
    void Start()
    {
        PrepareMines();
    }

    void PrepareMines(){
        btnImage.interactable = true;
        btnImage.image.sprite = btnunlocked;
        minesLeft = 5;
        btnText.text = "5 Mines";
        timeElapsed = 0f;
        secondPassed = 0f;
        unavailable = false;
        audio.Play();

    }

    public void dragMine()
    {
        minesLeft--;
        btnText.text = minesLeft + " Mines";
        minePlacement = true;
        mine = Instantiate(minePrefab) as GameObject;
        mine.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.25f);
        if (minesLeft == 0)
        {
            print("OUT OF MINES");
            btnImage.interactable = false;
            btnImage.image.sprite = btnlocked;
            unavailable = true;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(minePlacement){
        mine.transform.position = mousePos;
        }
        if (Input.GetMouseButtonDown(0) && minePlacement && Time.timeScale != 0f && !(Time.time - lastClick < 1))
        {
            mine.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            mine.transform.position = mousePos;
            mine.GetComponent<mine>().MinePlaced();
            minePlacement = false;
        }
        if (unavailable)
        {
            timeElapsed += Time.deltaTime;
            secondPassed += Time.deltaTime;
            if (secondPassed > 1f)
            {
                btnText.text = mineTimeout - Math.Truncate(timeElapsed) + " Seconds";
                secondPassed = 0f;
            }
            if (timeElapsed > mineTimeout)
            {
                PrepareMines();
            }

        }
    }
}
