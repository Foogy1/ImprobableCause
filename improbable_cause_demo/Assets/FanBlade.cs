using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlade : MonoBehaviour {
    public float magnitude = 5.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 directionalForce = new Vector3();
        directionalForce = collision.transform.position - transform.position;
        Vector2 orthoVect = new Vector2(directionalForce.x, directionalForce.z);
      collision.gameObject.GetComponent<Rigidbody>().AddForce(directionalForce * magnitude);
    }
}
