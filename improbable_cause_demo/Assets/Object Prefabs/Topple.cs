using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour
{
    public float TurningRate = 450.0f;
    private bool isTriggered = false;
    private Quaternion TargetRotation;
    public HeldObject heldObject;

    public bool IsTriggered
    {
        get { return isTriggered; }
    }

    void Start()
    {
        heldObject = FindObjectOfType<HeldObject>();
        TargetRotation = this.transform.rotation;
    }

    void Update() { 
        
    }

    public void SLERP(Vector2 force)
    {
        float forceAngle = Mathf.Atan2(force.x, force.y);
        float angle = forceAngle - transform.localRotation.z;

        Debug.Log(forceAngle);
        Debug.Log(angle);

        if (angle < 180 * Mathf.Deg2Rad)
            angle = -90;
        else
            angle = 90;

        if (!IsTriggered)
        {
            TargetRotation = Quaternion.AngleAxis(angle, this.transform.up);
            Debug.Log("changing rotation");
            isTriggered = true; 
        }
    }

    private void PlaySound()
    {
        this.gameObject.GetComponent<HitSound>().PlaySoundTopple(this.gameObject);
        isTriggered = false;
    }

    private void SearchNearby()
    {
        //Find Domino in topple rotation direction
        //Topple that Domino
    }

    // code that gray wrote
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "DominoCollision")
        { 
            // collision with other domino
            if (IsTriggered == false)
            {
                Debug.Log("IS TRIGGERED false");
                // get the vector from this domino to the other
                Vector3 directionalForce = new Vector3();
                directionalForce = collision.transform.position - transform.position;
                Vector2 orthoVect = new Vector2(directionalForce.x, directionalForce.z);
                SLERP(orthoVect);
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
