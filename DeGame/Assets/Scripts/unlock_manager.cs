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
        //coin.changeCoins(9999);
        //PlayerPrefs.SetString("unlocked_planets","");
        coin_value.text = "" + coin.getCoins();
        showUnlockedSkins();
        notifySelect(PlayerPrefs.GetString("planet_texture"));
    }

    void showUnlockedSkins()
    {
        print(PlayerPrefs.GetString("unlocked_planets"));
        string[] unlockedPlanets = PlayerPrefs.GetString("unlocked_planets").Split(',');
        foreach (var go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (go.tag == "unlock")
            {
                Image texture = go.GetComponent<Image>();
                foreach (string planet in unlockedPlanets)
                {
                    if (texture.mainTexture.name == planet)
                    {
                        print(planet + " unlocked");
                        go.transform.GetChild(0).GetComponent<Text>().text = "UNLOCKED";
                    }
                }
            }
        }
    }

    public void UnlockChosen(GameObject skin)
    {
        Image texture = skin.GetComponent<Image>();
        if (skin.transform.GetChild(0).GetComponent<Text>().text != "UNLOCKED")
        {
            string valueStr = skin.transform.GetChild(0).GetComponent<Text>().text;
            valueStr = valueStr.Substring(0, valueStr.Length - 6);
            int value = System.Convert.ToInt32(valueStr);
            if (coin.getCoins() < value)
            {
                print("Insufficient coin amount");
                return;
            }
            string unlockedPlanets = PlayerPrefs.GetString("unlocked_planets");
            unlockedPlanets = unlockedPlanets + "," + texture.mainTexture.name;
            PlayerPrefs.SetString("unlocked_planets", unlockedPlanets);
            coin.changeCoins(-value);
            coin_value.text = "" + coin.getCoins();
            skin.transform.GetChild(0).GetComponent<Text>().text = "UNLOCKED";
        };
        PlayerPrefs.SetString("planet_texture", texture.mainTexture.name);
        notifySelect(PlayerPrefs.GetString("planet_texture"));
    }
    void notifySelect(string name)
    {
        GameObject notify_text = GameObject.Find("skin_notify");
        notify_text.GetComponent<Text>().text = "Current planet: " + name;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
