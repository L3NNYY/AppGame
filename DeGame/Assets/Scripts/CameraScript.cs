using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    MenuScript menu;
    bool animationRunning = false;
    GameObject MainCamera;
    EarthRotate earthRotate;
    int estimatedFrames;
    int frameTracker;
    string sceneName;
    float step;
    float original;
    void Start()
    {
        earthRotate = GameObject.Find("3D Earth").GetComponent<EarthRotate>();
        //menu = gameObject.AddComponent<MenuScript>();

        MainCamera = GameObject.Find("Main Camera");
        earthRotate = GameObject.Find("3D Earth").GetComponent<EarthRotate>();
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("GameScene"))
        {
            menu = GameObject.Find("Game UI").GetComponent<MenuScript>();
            //pause = GameObject.Find("Game UI").GetComponent<PauseMenuScript>();
        }
        else
        {
            menu = GameObject.Find("MainMenu").GetComponent<MenuScript>();
        }
    }


    private void Anim(string transitionType)
    {

        //main camera configuration
        step += 0.04f; //change pseudo smoothness lower = smoother
        //
        
        earthRotate.AdjustSpinSpeed(frameTracker, estimatedFrames);
        if (transitionType == "in")
        {
            MainCamera.GetComponent<Camera>().orthographicSize = original - step;
            if (MainCamera.GetComponent<Camera>().orthographicSize <= 0.5f)
            {
                animationRunning = false;
                earthRotate.saveRotation();
                menu.setter();
            }
        }
        else if (transitionType == "out")
        {
            MainCamera.GetComponent<Camera>().orthographicSize = original + step;
            if (MainCamera.GetComponent<Camera>().orthographicSize >= 5f)
            {
                animationRunning = false;
                earthRotate.saveRotation();
                menu.setter();
            }
        }
        else
        {
            print("CameraCript/Anim/Error - invalid transition type");
        }
    }


    private IEnumerator AnimationIterator(string transitionType)
    {
        original = MainCamera.GetComponent<Camera>().orthographicSize;
        animationRunning = true;

        if (transitionType.Equals("in")){
            estimatedFrames = (int)earthRotate.EvaluateMe(original, 0.5f, 0.04f);
            Time.timeScale = 1f;
        } 
        else if (transitionType.Equals("out"))
        {
            earthRotate.rotationSpeed = 250;
            estimatedFrames = (int)earthRotate.EvaluateMe(original, 5f, 0.04f);
        }

        if (transitionType.Equals("in") || transitionType.Equals("out"))
        {
            while (animationRunning == true)
            {
                Anim(transitionType);
                frameTracker += 1;
                yield return null;
            }
        }
        else
        {
            print("Incorrect transitionType. Possible transitionTypes: in, out");
            animationRunning = false;
        }
        yield return null;
    }
    public void PlayTransitionAnimation(string transitionType)
    {
        StartCoroutine(AnimationIterator(transitionType));
    }
}
