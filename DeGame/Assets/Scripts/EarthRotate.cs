using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthRotate : MonoBehaviour
{

    public float rotationSpeed;
    float time;
    public float smoothness;
    public Vector3 earthRotation;
    public AnimationCurve someCurve; // MUST BE PUBLIC!!!
    public float animationSpeed;

    void Start()
    {
        earthRotation = new Vector3(PlayerPrefs.GetFloat("earth_rotation_x"), PlayerPrefs.GetFloat("earth_rotation_y"), PlayerPrefs.GetFloat("earth_rotation_z"));
        transform.eulerAngles = earthRotation;
        rotationSpeed = 5;
        smoothness = .1f;
        animationSpeed = 1f;
        time = 0f;
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            rotationSpeed = 400;
        }
        else if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            rotationSpeed = 5;
            smoothness = .05f;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= smoothness)
        {
            time = 0;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * animationSpeed);
            earthRotation = transform.eulerAngles;
        }
        // print(earthRotation);
    }

    public void saveRotation()
    {
        PlayerPrefs.SetFloat("earth_rotation_x", earthRotation.x);
        PlayerPrefs.SetFloat("earth_rotation_y", earthRotation.y);
        PlayerPrefs.SetFloat("earth_rotation_z", earthRotation.z);
    }
    public float EvaluateMe(float startingVal, float finalVal, float step)
    {
        int counter = 0;
        if (step > 0)
        {
            while (startingVal < finalVal)
            {
                counter += 1;
                startingVal += step;
            }
        }
        else if (step < 0)
        {
            while (startingVal < finalVal)
            {
                counter += 1;
                startingVal -= step;
            }
        }
        else
        {
            print("step cannot be zero");
            counter = -1;
        }
        return counter;
    }
    public void AdjustSpinSpeed(float counter, int estimatedFrames)
    {
        //animationSpeed = someCurve.Evaluate(counter / estimatedFrames);
    }
}
