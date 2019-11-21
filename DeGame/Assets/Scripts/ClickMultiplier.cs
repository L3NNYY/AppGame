using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickMultiplier : MonoBehaviour
{
    private Stack hits;
    public Text multiText;
    public Text multiLabel;
    Vector3 originalMultiTextSize, origLabelSize;
    Vector3 origPos;
    float animTime;
    int streak;
    int scoreMultiplier;
    bool hideMultiplier;
    bool showMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        origPos = multiText.transform.position;
        originalMultiTextSize = multiText.transform.localScale;
        origLabelSize = multiLabel.transform.localScale;
        multiLabel.gameObject.SetActive(false);
        multiText.gameObject.SetActive(false);
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        multiText.transform.position = shakeObject(streak * 2);

        if(showMultiplier){
            animMultiplier(false);
        }
        if(hideMultiplier){
            animMultiplier(hideMultiplier);
        }
    }
    public void IncrementStreak()
    {
        float sizeIncrement = (float)streak/5f;
        streak += 1;
        multiText.color = Color.Lerp(Color.white,Color.red,sizeIncrement);
        multiText.transform.localScale = Vector3.Lerp(originalMultiTextSize,new Vector3(2f,2f,1.46f), sizeIncrement);
        handleStreak();
    }
    private Vector3 shakeObject(int shakeIntensity){
        Vector3 newPos = origPos;
        newPos.y = Random.Range(origPos.y, origPos.y + (float)shakeIntensity);
        newPos.x = Random.Range(origPos.x, origPos.x + (float)shakeIntensity);
        return newPos;
    }
    private void handleStreak()
    {
        if (streak % 5 == 0)
        {
            streak = 0;
            scoreMultiplier += 1;
            multiText.text = "" + scoreMultiplier;
            multiText.color = Color.white;
            multiText.transform.localScale = originalMultiTextSize;

            if(multiText.gameObject.activeSelf == false){
                showMultiplier = true;
            }
        }
    }

    void animMultiplier(bool hide){
        animTime += Time.deltaTime * 3;
        if(hide){
            multiText.transform.localScale = Vector3.Lerp(originalMultiTextSize, new Vector3(0.1f,0.1f,0.1f), animTime);
            multiLabel.transform.localScale = Vector3.Lerp(origLabelSize, new Vector3(0.1f,0.1f,0.1f), animTime);
        }
        else{
            multiLabel.gameObject.SetActive(true);
            multiText.gameObject.SetActive(true);
            multiText.transform.localScale = Vector3.Lerp(new Vector3(0.1f,0.1f,0.1f),originalMultiTextSize, animTime);
            multiLabel.transform.localScale = Vector3.Lerp(new Vector3(0.1f,0.1f,0.1f),origLabelSize, animTime);
        }
        if(animTime >= 1f){
            animTime = 0;
            showMultiplier = false;
            if(hide){
                multiLabel.gameObject.SetActive(false);
                multiText.gameObject.SetActive(false);
                hideMultiplier = false;
            }
        }
    }
    public int getScoreMultiplier()
    {
        return scoreMultiplier;
    }
    /*public void BackgroundClick() //button click function
    {
        if (hits.Count != 0)
        {
            hits.Pop();
        }
        else
        {
            resetStreakAndMultiplier();
        }
        */
        //if (Time.timeScale != 0f)
        //{
        //    hits.Push("CLICK");
        //    if (hits.Count != 0)
        //    {
        //        print("hit!");
        //        //hit = false;
        //    }
        //    else
        //    {
        //       print("you missed!");
        //        resetStreakAndMultiplier();
        //    }
        //}
    //}
    public void resetStreakAndMultiplier()
    {
        hideMultiplier = true;
        streak = 0;
        scoreMultiplier = 1;
    }
    public void hitSetter()
    {
        hits.Push("CLICK!");
    }
}
