using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{

    // Start is called before the first frame update
    public void changeCoins(int amount){
        int coin = PlayerPrefs.GetInt("coins") | 0;
        PlayerPrefs.SetInt("coins", coin + amount);
    }

    public int getCoins(){
        return PlayerPrefs.GetInt("coins");
    }

}
