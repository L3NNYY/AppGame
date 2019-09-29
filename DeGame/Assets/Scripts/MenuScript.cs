using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    EarthRotate earthR;
    void Start(){
        earthR = GameObject.Find("3D Earth").GetComponent<EarthRotate>();
    }
    public void PlayGame()
    {
        earthR.saveRotation();
        SceneManager.LoadScene("GameScene");
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        earthR.saveRotation();
        SceneManager.LoadScene("MenuScene");
    }
}
