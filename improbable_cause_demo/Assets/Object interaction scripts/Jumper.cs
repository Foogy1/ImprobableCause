using UnityEngine;

public class Jumper : IUsable
{
    /* Inherits from the IUsable class. This item will jump in place or between two anchor points.
     The trajectory can be modified in the inspector.*/
    private GameObject startingPoint;
    private GameObject targetPoint;
    public GameObject originalTargetPoint;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool startThrow = true;
    private float cTime = 0;

    [Tooltip("Time between jumps")]
    public float timer = 10;

    [Tooltip("If the object jumps between 2 or more points, this is the time between jumps.")]
    public float cooldown = 10;

    [Tooltip("Minimum distance needed for object to 'snap' to position.")]
    public float minDistance = 0.5f;

    [Tooltip("Jump height")]
    public float trajectoryHeight = 5f;

    [Tooltip("If set to true, object will jump in place indefinitely.")]
    public bool inPlace = false;

    [Tooltip("Object will do action on timer.")]
    public bool onTimer = false;

    public override void Start()
    {
        objectType = ObjectType.Jumper;
        targetPoint = originalTargetPoint;
        endPos = targetPoint.transform.position;
    }

    private void Update()
    {
        if (anchorPoint)
        {
            if (startThrow)
            {
                // Checks to make sure the anchor point that is it's target is unoccupied (including the anchor point that
                // it launches from). The trajectory is calculated and the object moves to the new location (or stays in the
                // same place if inPlace = true.
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
                if (timer <= 0)
                {
                    startThrow = true;
                    timer = cooldown;
                }
            }
            if (targetPoint.GetComponent<AnchorPoint>().IsOccupied == true) return;
        }
    }

    public void move(GameObject dropLocation)
    {
        startingPoint.GetComponent<AnchorPoint>().IsOccupied = false;
        if (dropLocation.GetComponent<AnchorPoint>().IsOccupied == false || inPlace)
        {
            gameObject.layer = DEFAULT_LAYER;
            gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
            dropLocation.GetComponent<AnchorPoint>().setObject();
        }
    }

    public override void place(GameObject dropLocation, AnchorPoint anchorPoint)
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
        // Stops moving object.
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.layer = DEFAULT_LAYER;
        gameObject.transform.position = anchorPoint.GetPosition(GetComponent<Renderer>().bounds.size.y);
        startThrow = true;
        // Resets the timer if necessary.
        if (onTimer)
        {
            timer = cooldown;
        }
    }

    public override void pickUp()
    {
        if (startingPoint)
        {
            startingPoint.GetComponent<AnchorPoint>().IsOccupied = false;
        }
        gameObject.layer = IGNORE_RAYCAST_LAYER;
        if (anchorPoint)
        {
            anchorPoint.IsOccupied = false;
            anchorPoint = null;
        }
    }

    // Gets Euclidean distance between the current object's position and the target.
    private float getDistance(GameObject go)
    {
        float distance = Vector3.Distance(transform.position, go.transform.position);
        return distance;
    }
}