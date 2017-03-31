using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public float timerDuration = 2.0f;
    private float timer;
    public void Start()
    {
        timer = timerDuration;
    }

    public void OnRestart() { }
}
