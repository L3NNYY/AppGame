﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour {

    float rotationSpeed = 400;
    float time = 0f;

    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time >= .25f) {
            time = 0;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}