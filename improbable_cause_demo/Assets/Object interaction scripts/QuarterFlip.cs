using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class QuarterFlip : MonoBehaviour {


	private bool flipTime;
	// Use this for initialization
	void Start () {
		flipTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 20) {
			Debug.Log ("called");
			flipTime = false;
			//EditorSceneManager.LoadScene (WinScene);
		}
		if (flipTime == true) {
			this.transform.Translate (0, .5f, 0, Space.World);
			this.transform.Rotate (0, 0, 30);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		IUsable usable = collision.gameObject.GetComponent<IUsable>();
		if (usable) {
			flipTime = true;
		}
	}
}
