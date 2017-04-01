using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClock : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        Invoke("OpenDoors", 1);
	}

    public void CloseDoors()
    {
        anim.SetBool("isOpen", false);
    }

    public void OpenDoors()
    {
        anim.speed = 1;
        anim.SetBool("isOpen", true);
    }
}
