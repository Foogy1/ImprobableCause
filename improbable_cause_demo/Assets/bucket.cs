using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : AnchorPoint {
    public float offset = -25.0f;
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


    void grabObject(GameObject obj)
    {
        Vector3 position = GetPosition(obj.GetComponent<Renderer>().bounds.size.y);
        position.x += offset;
        obj.transform.position = position;
        setObject();
    }
}
