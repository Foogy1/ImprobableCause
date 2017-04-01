using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public float timerDuration = 2.0f;
    private float timer;
    private Animator anim;
    private Collider coll;
    public void Start()
    {
        timer = timerDuration;
        coll = GetComponent<Collider>();
        anim = GetComponentInParent<Animator>();
    }

    public void OnRestart() {
        coll.enabled = false;
     //   anim.
    }


    public void OnStart()
    {

    }
}
