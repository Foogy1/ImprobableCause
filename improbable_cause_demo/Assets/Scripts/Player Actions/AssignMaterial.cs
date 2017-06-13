using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMaterial : MonoBehaviour {
    public Material floorMaterial;
    // Use this for initialization
    void Start() {
        GameObject[] aps = GameObject.FindGameObjectsWithTag("AnchorPoint");
        foreach (GameObject ap in aps)
        {
            ap.GetComponent<Renderer>().material = floorMaterial;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
