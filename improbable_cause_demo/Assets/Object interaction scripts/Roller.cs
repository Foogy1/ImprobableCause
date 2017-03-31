using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Roller : IUsable {
    public float FORCE = 2.0f;
    public float blockSize = 2.5f;
    public float distance = 3;
    Rigidbody rb;
    Vector3 target;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Room") && !collision.gameObject.CompareTag("AnchorPoint"))
        {
            Vector3 point = collision.contacts[0].point;
            Vector3 direction = point - transform.position;
            direction = -direction.normalized;
            target.x =  transform.position.x + (direction.x + (blockSize * distance));
            target.y = transform.position.y;
            target.z = transform.position.y + (direction.y + (blockSize * distance));
            Vector3 newPos = target - transform.position;
            newPos = newPos.normalized;
            rb.AddForce(newPos * FORCE);


        }
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
