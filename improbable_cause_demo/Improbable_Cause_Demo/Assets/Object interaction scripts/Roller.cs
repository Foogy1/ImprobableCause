using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : IUsable {

  //  public direction direction;
	private enum direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
    };

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}


}
