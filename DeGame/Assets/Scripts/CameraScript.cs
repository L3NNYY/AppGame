using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    MenuScript menu;
    PauseMenuScript pause;
    GameObject MainCamera;
    baseStats earth;
    float zoom = 0.3f;
    float normal = 5f;
    float smooth = 0.1f;
    float time;
    // Start is called before the first frame update
    bool menuAnim = false;
    bool startOfGame = true;
    // Update is called once per frame
    void Start()
    {
        earth = GameObject.Find("3D Earth").GetComponent<baseStats>();
        menu = GetComponent<MenuScript>();
        pause = GetComponent<PauseMenuScript>();
        MainCamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (menuAnim)
        {
            ZoomInAnim(true);
        }
        else if (startOfGame)
        {
            ZoomInAnim(false);
        }
    }

    void ZoomInAnim(bool zoomIn)
    {
        time += Time.deltaTime;
        if (time > 0.01f)
        { //prevents zoom in to be done using framerate/tick rate, instead depends on deltaTime
            time = 0;
            smooth += 0.01f;
        }
        if (zoomIn)
        {
            pause.deathScreen.SetActive(false);
            MainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(normal, zoom, smooth);
            if (MainCamera.GetComponent<Camera>().orthographicSize <= zoom)
            {
                menuAnim = false;
                smooth = 0;
                menu.GoToMenu();
            }
        }
        else
        {
            MainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(zoom, normal, smooth);
            if (MainCamera.GetComponent<Camera>().orthographicSize >= 5f)
            {
                startOfGame = false;
                smooth = 0;
                earth.godmode = false;
            }
        }
    }

    public void activateMenuAnim()
    {
        pause.Resume();
        earth.godmode = true;
        menuAnim = true;
    }
}
