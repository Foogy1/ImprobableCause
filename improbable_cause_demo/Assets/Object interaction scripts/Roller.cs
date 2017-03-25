using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Roller : MonoBehaviour {
    public float FORCE = 2.0f;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Room") && !collision.gameObject.CompareTag("AnchorPoint"))
        {
            Vector3 point = collision.contacts[0].point;
            Vector3 direction = point - transform.position;
            direction = -direction.normalized;
            if (rb != null)
            {
              //  rb.AddForce(direction * FORCE);
            }
        }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
