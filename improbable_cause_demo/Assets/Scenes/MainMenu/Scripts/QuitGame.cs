using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	public void ClickExit()

	{
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		if (Input.GetMouseButtonDown (0)) {
			Application.Quit ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
