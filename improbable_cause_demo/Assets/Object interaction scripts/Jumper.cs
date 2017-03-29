using UnityEngine;

public class Jumper : IUsable
{
    /* Inherits from the IUsable class. This item will jump in place or between two anchor points.
     The trajectory can be modified in the inspector.*/
    private GameObject startingPoint;
    Vector3 targetPoint;
  //  public GameObject originalTargetPoint;
    private Vector3 startPos;
    
    private bool startThrow = false;
    private float cTime = 0;
    public float distance = 6.0f;
    public float blockSize = 2.5f;

    [Tooltip("Minimum distance needed for object to 'snap' to position.")]
    public float minDistance = 0.5f;

    [Tooltip("Jump height")]
    public float trajectoryHeight = 5f;

    [Tooltip("If set to true, object will jump in place indefinitely.")]
    public bool inPlace = false;

    public override void Start()
    {        objectType = ObjectType.Launcher;

        //targetPoint = null;
      //  endPos = targetPoint.transform.position;
    }

    public void StartCatapult()
    {
        Debug.Log("StartCatapult");
        startThrow = true;
    }
    private void Update()
    {
            if (startThrow)
            {
        
                // Checks to make sure the anchor point that is it's target is unoccupied (including the anchor point that
                // it launches from). The trajectory is calculated and the object moves to the new location (or stays in the
                // same place if inPlace = true.
                cTime += 0.04f;
                 Vector3 startingPosition = transform.position;
                Vector3 currentPos = Vector3.Lerp(startingPosition, targetPoint, cTime);
                currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
                transform.position = currentPos;

                if (transform.position == targetPoint)
                {
              //      move(targetPoint);
                    startThrow = false;
                    cTime = 0;
                }
            }
           // if (targetPoint.GetComponent<AnchorPoint>().IsOccupied == true) return;
    }

    public void move(Vector3 dropLocation)
    {
        startingPoint.GetComponent<AnchorPoint>().IsOccupied = false;
 
            gameObject.layer = DEFAULT_LAYER;
            gameObject.transform.position = dropLocation;
            
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

    public override void place(GameObject dropLocation, AnchorPoint anchorPoint)
    {
        this.anchorPoint = anchorPoint;
        gameObject.layer = DEFAULT_LAYER;
        Debug.Log(dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y));
        //gameObject.transform.localRotation = dropLocation.transform.localRotation;
        gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
        bucket bucket = dropLocation.GetComponent<bucket>();
        startingPoint = dropLocation;
        if (bucket)
        {
            bucket.changeAngle();
            targetPoint = transform.position;
            targetPoint.z = transform.position.z + (distance * blockSize);
            startThrow = true;
        }
        try
        {
            gameObject.GetComponent<HitSound>().PlaySound(gameObject);
        }
        catch
        {
            Debug.LogError("You have not attached the HitSound Script to this object");
        }

    }

    // Gets Euclidean distance between the current object's position and the target.
    private float getDistance(Vector3 other)
    {
        float distance = Vector3.Distance(transform.position, transform.position);
        return distance;
    }
}