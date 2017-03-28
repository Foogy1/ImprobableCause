using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    public float speed = 4.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // float speed = 4.0f;
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * (-1f * speed));
       // transform.Rotate(Vector3.right * Time.deltaTime * speed);

    }
}
