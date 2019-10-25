using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class unlock_manager : MonoBehaviour
{
    public Text coin_value;
    coins coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = gameObject.AddComponent<coins>();
        coin.changeCoins(9999);
        coin_value.text = "" + coin.getCoins();
    }

    public void UnlockChosen(GameObject skin){
        int value = System.Convert.ToInt32(skin.transform.GetChild(0).GetComponent<Text>().text);
        if(coin.getCoins() < value){
            print("Insufficient coin amount");
            return;
        }
        Image texture = skin.GetComponent<Image>();
        PlayerPrefs.SetString("planet_texture",texture.mainTexture.name);
        coin.changeCoins(-value);
        coin_value.text = "" + coin.getCoins();
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
