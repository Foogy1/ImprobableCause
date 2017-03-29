using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : AnchorPoint {
    public float offset = -25.0f;
    public GameObject catapultBucket;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jumper>() && IsOccupied != true)
        {
            if (fitsOnBucket(collision.gameObject))
            {
                grabObject(collision.gameObject);
            }
        }

    }


    bool fitsOnBucket(GameObject go)
    {
        return true;
    }

    public override Vector3 GetPosition(float objectSize)
    {
        return catapultBucket.transform.position;
    }

    public override void setObject()
    {
        IsOccupied = true;
    }

   public void changeAngle()
    {
        transform.Rotate(new Vector3(45.0f, 0, 0));
        IsOccupied = false;
    }


    void grabObject(GameObject obj)
    {
        obj.transform.position = catapultBucket.transform.position;
        setObject();
        Jumper jumper = obj.GetComponent<Jumper>();
        if(jumper != null)
        {
            jumper.StartCatapult();
            changeAngle();
        }
    }
}
