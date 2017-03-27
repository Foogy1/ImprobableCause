using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propellable : MonoBehaviour {

	public GameObject anchorPointDown;
	public GameObject anchorPointMiddle;
	public GameObject anchorPointLaunch;


	//here are the bools that check when it's acceptable for a propeller to be in certain states
	//all already guarantee the propeller being on a fulcrum

	//the propeller is tilted down with the anchorPointDown side touching the floor. No object is on it
	public bool readyToMoveDown = false;

	//the propeller is tilted down with the anchorPointLaunch side touching the floor. No object is on it
	public bool readyToMoveLaunch = false;

	//the propeller is tilted down with the anchorPointDown side touching the floor. An object is on anchorPointDown
	public bool readyToPropelDown = false;

	//the propeller is tilted down with the anchorPointLaunch side touching the floor. An object is on anchorPointLaunch
	public bool readyToPropelLaunch = false;

	//the propeller is tilted down with the anchorPointDown side touching the floor.
	//An object is on anchorPointDown and an object just collided with anchorPointLaunch, which will launch the object on anchorPointDown
	//and tilt the propeller to now have the anchorPointLaunch side touching the floor
	public bool isPropellingDown = false;

	//the propeller is tilted down with the anchorPointLaunch side touching the floor.
	//An object is on anchorPointLaunch and an object just collided with anchorPointDown, which will launch the object on anchorPointLaunch
	//and tilt the propeller to now have the anchorPointDown side touching the floor
	public bool isPropellingLaunch = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (checkForFulcrum () == true && checkForDownDown () == true) {
			readyToMoveDown = true;
			if (objectToFireDown () == true) {
				readyToPropelDown = true;
			}
		} else if (checkForFulcrum () == true && checkForDownLaunch () == true) {
			readyToMoveLaunch = true;
			if (objectToFireLaunch () == true) {
				readyToPropelLaunch = true;
			}
		}
		else {
			readyToMoveDown = false;
			readyToMoveLaunch = false;
			readyToPropelDown = false;
			readyToPropelLaunch = false;
		}

		if (readyToPropelDown == true) {
			AnchorPoint anchor = anchorPointLaunch.GetComponent<AnchorPoint> ();
			if (anchor.propellerDown == true) {
				isPropellingDown = true;
			} else {
				isPropellingDown = false;
			}
		}
		if (readyToPropelLaunch == true) {
			AnchorPoint anchor = anchorPointDown.GetComponent<AnchorPoint> ();
			if (anchor.propellerDown == true) {
				isPropellingLaunch = true;
			} else {
				isPropellingLaunch = false;
			}
		}
	}

	//since fulcrums collide with the middle bottom of propellers, not sure what the best check for this is - this is probably wrong
	//perhaps we can set the propeller itself to check for this, if the fulcrum will only allow the middle gridspace of propellers to be placed on top of it
	public bool checkForFulcrum(){
		AnchorPoint anchor = anchorPointMiddle.GetComponent<AnchorPoint> ();
		if (anchor) {
			if (anchor.fulcrumReady == true) {
				return true;
			}
		}
		return false;
	}

	public bool checkForDownDown(){
		if (anchorPointLaunch.transform.position.y > anchorPointDown.transform.position.y) {
			return true;
		}
		return false;
	}

	public bool checkForDownLaunch(){
		if (anchorPointDown.transform.position.y > anchorPointLaunch.transform.position.y) {
			return true;
		}
		return false;
	}

	public bool objectToFireDown(){
		AnchorPoint anchorDown = anchorPointDown.GetComponent<AnchorPoint> ();
		if (anchorDown.propellerDown == true) {
			return true;
		}
		return false;
	}

	public bool objectToFireLaunch(){
		AnchorPoint anchorLaunch = anchorPointLaunch.GetComponent<AnchorPoint> ();
		if (anchorLaunch.propellerDown == true) {
			return true;
		}
		return false;
	}
}
