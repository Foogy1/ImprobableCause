using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    public float maxSpeed = 4.0f;
	//public float TorquePerTick = 26000.0f;
	// Use this for initialization
	private Rigidbody rb;
	void Start () {
		
		rb = transform.GetComponent<Rigidbody>();
		if(rb == null)
			Debug.LogException (new UnityException("Error: submesh component not found. Please attach one."));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(rb != null && rb.angularVelocity.magnitude <= maxSpeed)
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * maxSpeed);
    }
}
