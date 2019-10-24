using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private CameraScript cam;
    private GameObject UI;
    private AsyncOperation a;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        UI = this.gameObject;

    }
    public void PlayGame()
    {
        StartCoroutine(Some("GameScene"));
        cam.PlayTransitionAnimation("out");
        UI.SetActive(false);
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
        StartCoroutine(Some("MenuScene"));
        cam.PlayTransitionAnimation("in");
        UI.SetActive(false);
        GameObject.Find("Asteroids").SetActive(false);

    }
    IEnumerator Some(string sceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.progress >= 0.9f)
        {

            yield return null;
        }
        getter(asyncLoad);
        yield return null;

    }
    public void setter()
    {
        a.allowSceneActivation = true;
    }
    public void getter(AsyncOperation b)
    {
        a = b;
    }
}
