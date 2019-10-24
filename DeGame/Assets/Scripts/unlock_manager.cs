using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class unlock_manager : MonoBehaviour
{
    int coinPurse = 165;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockChosen(GameObject skin){
        int value = System.Convert.ToInt32(skin.transform.GetChild(0).GetComponent<Text>().text);
        if(coinPurse < value){
            print("Insufficient coin amount");
            return;
        }
        Image texture = skin.GetComponent<Image>();
        PlayerPrefs.SetString("planet_texture",texture.mainTexture.name);
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
