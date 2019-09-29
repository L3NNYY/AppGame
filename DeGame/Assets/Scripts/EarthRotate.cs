using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour {

    public float rotationSpeed = 400;
    float time = 0f;
    public float smoothness = .25f;
    public Vector3 earthRotation;

    // Start is called before the first frame update
    void Start() {
       earthRotation = new Vector3(PlayerPrefs.GetFloat("earth_rotation_x"),PlayerPrefs.GetFloat("earth_rotation_y"),PlayerPrefs.GetFloat("earth_rotation_z"));
       transform.eulerAngles = earthRotation;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time >= smoothness) {
            time = 0;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            earthRotation = transform.eulerAngles;
        }
        print(earthRotation);
    }
    
    public void saveRotation(){
        PlayerPrefs.SetFloat("earth_rotation_x", earthRotation.x);
        PlayerPrefs.SetFloat("earth_rotation_y", earthRotation.y);
        PlayerPrefs.SetFloat("earth_rotation_z", earthRotation.z);
    }
}
