using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

    public GameObject MyCube;
    private float t;

    void Start()
    {
       // MyCube = GameObject.Find("Brain");
        t = (float)0.1;
    }

    void Update()
    {
        MyCube.transform.Rotate(1*t, 1*t, 0);
    }
}