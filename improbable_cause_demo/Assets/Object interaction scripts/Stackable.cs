using UnityEngine;

public class Stackable : IUsable
{
    /* IUsables can be placed on this object */

	public GameObject spawnableAnchorPointPrefab;
	public GameObject currentSpawnedAnchorPoint;

    /*protected override void Start()
    {
       
    }*/



	public override void place(GameObject dropLocation, AnchorPoint anchorPoint)
	{
		this.anchorPoint = anchorPoint;
		gameObject.layer = DEFAULT_LAYER;
		Debug.Log(dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y));
		//gameObject.transform.localRotation = dropLocation.transform.localRotation;
		gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
		Vector3 currentCrateLocation = this.transform.position; //(this.transform.position.x, 
		currentCrateLocation.y += 0.7f;
		//currentCrateLocation.x += 0.5f;
		currentSpawnedAnchorPoint = Instantiate (spawnableAnchorPointPrefab, currentCrateLocation, Quaternion.identity);
	}

	public override void pickUp()
	{
		gameObject.layer = IGNORE_RAYCAST_LAYER;
		if (anchorPoint)
		{
			anchorPoint.IsOccupied = false;
			anchorPoint = null;
		}
		if (currentSpawnedAnchorPoint != null) {
			Destroy (currentSpawnedAnchorPoint);
		}
	}

}