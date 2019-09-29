using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour {

    public float rotationSpeed = 400;
    float time = 0f;
    public float smoothness = .25f;

    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time >= smoothness) {
            time = 0;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
