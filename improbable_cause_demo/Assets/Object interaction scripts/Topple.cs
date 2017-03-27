using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour {
    public float TurningRate = 450.0f;
    public bool IsDown;
    private bool triggerinokripperino = false;
    private Quaternion TargetRotation;
    void Start () {
        TargetRotation = this.transform.rotation; 
	}

	void Update () {
        
        if (TargetRotation != this.transform.rotation)
        {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, TargetRotation, TurningRate * Time.deltaTime);
            triggerinokripperino = true;
        }
        if (triggerinokripperino && TargetRotation == this.transform.rotation)
        {
            PlaySound();
        }
    }

    public void SLERP(float angle)
    {
        if (!IsDown)
        {
            TargetRotation = Quaternion.AngleAxis(angle, this.transform.up) * this.transform.rotation;
            IsDown = true;
        }
    }

    private void PlaySound()
    {
        this.gameObject.GetComponent<HitSound>().PlaySound(this.gameObject);
        triggerinokripperino = false;
    }

    private void SearchNearby()
    {
        //Find Domino in topple rotation direction
        //Topple that Domino
    }

}
