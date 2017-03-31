using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour {
    public float TurningRate = 450.0f;
    public bool IsDown;
    private bool triggerinokripperino = false;
    private Quaternion TargetRotation;

    public bool IsTriggered
    {
        get { return triggerinokripperino; }
    }

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

    public void SLERP(Vector2 force)
    {
        float forceAngle = Mathf.Atan2(force.x, force.y);
        float angle = forceAngle - transform.localRotation.z;

       //// Debug.Log(forceAngle);
       /// Debug.Log(angle);

        if (angle < 180 * Mathf.Deg2Rad)
            angle = -90;
        else
            angle = 90;

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

    // code that gray wrote
    private void OnCollisionEnter(Collision collision)
    {
      //  Debug.Log("BEFORE COLLISION");
        if (collision.gameObject.tag == "DominoCollision") 
        {
          //  Debug.Log("COLLISION!!!!");
            // collision with other domino
            if (IsTriggered == false)
            {
                // get the vector from this domino to the other
                Vector3 directionalForce = new Vector3();
                directionalForce = collision.transform.position - transform.position;
                Vector2 orthoVect = new Vector2(directionalForce.x, directionalForce.z);
                gameObject.GetComponent<Topple>().SLERP(orthoVect);
                // check that the other domino is not toppling
                if (collision.gameObject.GetComponent<Topple>() != null)
                {
                    if (!collision.gameObject.GetComponent<Topple>().IsTriggered)
                    {
                        Debug.Log("Triggering");
                        collision.gameObject.GetComponent<Topple>().SLERP(orthoVect);
                    }
                }
            }
        }
    }

}
