using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppleComponent : Component
{
    protected override void Start()
    {
        base.Start();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
    }






















    /* legacy topple
    public float TurningRate = 450.0f;
    public bool IsDown = false;
    private bool triggerinokripperino = false;
    private bool isStartRotation = false;
    public bool fell = false;
    private Quaternion TargetRotation;
    private Quaternion StartRotation;
    public HeldObject heldObject;

    public bool IsTriggered
    {
        get { return triggerinokripperino; }
    }

    public void IsStartRotation(bool bo)
    {
        isStartRotation = bo;
    }

    void Start()
    {
        heldObject = FindObjectOfType<HeldObject>();
        TargetRotation = this.transform.rotation;
        StartRotation = transform.rotation;
    }

    public void restart()
    {
        TargetRotation = StartRotation;
    }

    public void SetTargetRotation(Quaternion rotation)
    {
        TargetRotation = rotation;
    }

    void Update()
    {
        if (isStartRotation)
        {
            if (heldObject.getHeldObject() != this.gameObject)
            {
                if (TargetRotation != this.transform.localRotation)
                {
                    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, TargetRotation, TurningRate * Time.deltaTime);
                    triggerinokripperino = true;
                }
                if (triggerinokripperino && TargetRotation == this.transform.rotation && fell == false)
                {
                    //  if(IsDown == false) {
                    PlaySound();
                    // }
                }
            }
        }
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

        if (!IsDown)
        {
            TargetRotation = Quaternion.AngleAxis(angle, this.transform.up) * this.transform.rotation;
            IsDown = true;
        }
    }

    private void PlaySound()
    {
        fell = true;

        this.gameObject.GetComponent<HitSound>().PlaySoundTopple(this.gameObject);
        triggerinokripperino = false;
    }

    private void SearchNearby()
    {

    }

    // code that gray wrote
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BEFORE COLLISION");
        if (collision.gameObject.tag == "DominoCollision")
        {
            isStartRotation = true;
            Debug.Log("COLLISION!!!!");
            // collision with other domino
            if (IsTriggered == false)
            {
                //triggerinokripperino = true;
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
    } */

}