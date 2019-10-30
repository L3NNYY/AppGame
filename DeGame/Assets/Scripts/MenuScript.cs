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
        Destroy(GameObject.Find("Audio Manager"), 0f);
        StartCoroutine(Some("GameScene"));
        cam.PlayTransitionAnimation("out");
        UI.SetActive(false);
    }
    public void GoToUnlocks()
    {
        SceneManager.LoadScene("UnlocksScene");
    }
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
    public void OpenTwitter()
    {
        Application.OpenURL("https://www.twitter.com");
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
    public void GoToMenu_Death()
    {
        SpriteRenderer render = GameObject.Find("blackFade").GetComponent<SpriteRenderer>();
        Color tmp = render.color;
        tmp.a = 0f;
        render.color = tmp;
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
