using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClock : MonoBehaviour {
    public GameObject bird;
    Collider [] colliders;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        colliders = GetComponentsInChildren<Collider>();
        anim = GetComponent<Animator>();
        Invoke("OpenDoors", 1);
	}

    public void CloseDoors()
    {
       foreach(Collider col in colliders)
        {
            col.enabled = false;
        }
        anim.SetBool("isOpen", false);
    }

    public void OpenDoors()
    {
        anim.speed = 1;
        anim.SetBool("isOpen", true);
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }
}
