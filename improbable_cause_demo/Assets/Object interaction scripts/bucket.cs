using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : AnchorPoint {
    public float offset = -25.0f;
    public GameObject catapultBucket;
    public float timerDuration = 3.0f;
    private float timer = 0;
    public float speed = 1;
    private bool startTimer = false;

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

    public override void Start()
    {
        base.Start();
        timer = timerDuration;
    }

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
         //   Debug.Log(timer);
            if(timer <= 0)
            {
            //    Debug.Log("Timer is less than 0");
                startTimer = false;
                timer = timerDuration;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                IsOccupied = false;

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
        transform.localEulerAngles = new Vector3(45.0f, 0, 0);
        startTimer = true;
        IsOccupied = true;
    }


    void grabObject(GameObject obj)
    {
        obj.transform.position = catapultBucket.transform.position;
        setObject();
        Jumper jumper = obj.GetComponent<Jumper>();
        if(jumper != null)
        {
<<<<<<< HEAD
           jumper.StartCatapult();
=======
            jumper.StartCatapult();
>>>>>>> 8234fd0ddba956e70806f52427f0b5344538fb6a
            changeAngle();
        }
    }
}
