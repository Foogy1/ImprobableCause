using UnityEngine;

public class StackableComponent : BaseObject
{
    public GameObject spawnableAnchorPointPrefab;
    private GameObject currentSpawnedAnchorPoint;
    public float offset = 1f;
    public float ANCHORPOINT_HEIGHT = 0.3f;

    public override void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        InstantiateAnchorPoint();
    }

    public GameObject getSpawnedAnchorPoint()
    {
        return currentSpawnedAnchorPoint;
    }

    public override void place(GameObject dropLocation, AnchorPoint anchorPoint)
    {
        this.anchorPoint = anchorPoint;
        gameObject.layer = DEFAULT_LAYER;
        if (currentSpawnedAnchorPoint)
        {
            currentSpawnedAnchorPoint.layer = DEFAULT_LAYER;
        }
        gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
        InstantiateAnchorPoint();
        try
        {
            gameObject.GetComponent<HitSound>().PlaySound(gameObject);
        }
        catch
        {
            Debug.LogError("You have not attached the HitSound Script to this object");
        }
    }

    private void InstantiateAnchorPoint()
    {
        Vector3 currentCrateLocation = this.transform.position;
        currentCrateLocation.y += offset;
        currentSpawnedAnchorPoint = Instantiate(spawnableAnchorPointPrefab, currentCrateLocation, Quaternion.identity);
        currentSpawnedAnchorPoint.transform.localScale = new Vector3(GetComponent<Renderer>().bounds.size.x, ANCHORPOINT_HEIGHT, GetComponent<Renderer>().bounds.size.z);
        currentSpawnedAnchorPoint.transform.parent = gameObject.transform;
    }

    public override void pickUp()
    {
        gameObject.layer = IGNORE_RAYCAST_LAYER;
        if (currentSpawnedAnchorPoint)
        {
            currentSpawnedAnchorPoint.layer = IGNORE_RAYCAST_LAYER;
        }
        if (currentSpawnedAnchorPoint != null)
        {
            if (currentSpawnedAnchorPoint.GetComponent<AnchorPoint>().IsOccupied)
            {
                return;
            }
            else
            {
                Destroy(currentSpawnedAnchorPoint);
                if (anchorPoint != null)
                {
                    anchorPoint.IsOccupied = false;
                    anchorPoint = null;
                }
            }
        }
        else if (anchorPoint)
        {
            anchorPoint.IsOccupied = false;
            anchorPoint = null;
        }
        try
        {
            gameObject.GetComponent<HitSound>().PlaySoundPickUp(gameObject);
        }
        catch
        {
            Debug.LogError("You have not attached the HitSound Script to this object");
        }
    }
}