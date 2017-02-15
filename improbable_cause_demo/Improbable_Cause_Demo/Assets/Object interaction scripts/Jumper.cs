using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : IUsable {
    private GameObject startingPoint;
    private GameObject targetPoint;
    public GameObject originalTargetPoint;
    public bool inPlace = false;
    public bool onTimer = false;
    private Vector3 startPos;
    private Vector3 endPos;
    bool startThrow = true;
    public float cooldown = 10;
    public float timer;
    public float minDistance = 0.5f;
    public float trajectoryHeight = 5f;
    float cTime = 0;

    // Use this for initialization
    void Start () {
         targetPoint = originalTargetPoint;
        endPos = targetPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (holder)
        {
            if (startThrow)
            {
            
                cTime += 0.04f;
                Vector3 currentPos = Vector3.Lerp(startingPoint.transform.position, targetPoint.transform.position, cTime);
                currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
                transform.position = currentPos;

                if (transform.position == endPos || getDistance(targetPoint) < minDistance)
                {
                    move(targetPoint);
                    startThrow = false;
                    cTime = 0;
                    GameObject tempPos = targetPoint;
                    targetPoint = startingPoint;
                    startingPoint = tempPos;
                }
            }
                
            else if (onTimer)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    startThrow = true;
                    timer = cooldown;
                }
            }
            if (targetPoint.GetComponent<IHolder>().isOccupied == true) return;
        }
        	
	}

    public  void move(GameObject dropLocation)
    {
        startingPoint.GetComponent<IHolder>().removeObject();
        if (dropLocation.GetComponent<IHolder>().IsOccupied == false || inPlace)
        {
            gameObject.layer = DEFAULT_LAYER;
            gameObject.transform.position = dropLocation.GetComponent<IHolder>().GetPosition(GetComponent<Renderer>().bounds.size.y);
            dropLocation.GetComponent<IHolder>().setObject();
        }
    }

    public override void place(GameObject dropLocation)
    {
        if (!inPlace)
        {
            startingPoint = dropLocation;
            targetPoint = originalTargetPoint;
        }
        else
        {
            startingPoint = dropLocation;
            targetPoint = dropLocation;
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.layer = DEFAULT_LAYER;
        gameObject.transform.position = dropLocation.GetComponent<IHolder>().GetPosition(GetComponent<Renderer>().bounds.size.y);
        startThrow = true;
        timer = cooldown;
    }

    public override void pickUp()
    {
        if (startingPoint)
        {
            startingPoint.GetComponent<IHolder>().removeObject();
        }
        gameObject.layer = IGNORE_RAYCAST_LAYER;
        if (holder)
        {
            holder.removeObject();
            holder = null;
        }
    }

    float getDistance(GameObject go)
    {
       float distance = Vector3.Distance(transform.position, go.transform.position);
       return distance;
    }
}
