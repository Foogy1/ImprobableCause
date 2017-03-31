using UnityEngine;

public class Stackable : IUsable
{    

	public GameObject spawnableAnchorPointPrefab;
	private GameObject currentSpawnedAnchorPoint;
	public float offset = 1f;    


	public override void Start(){
        base.Start();
       // startingPosition = transform.position;
       // startingRotation = transform.rotation;
        Vector3 currentCrateLocation = this.transform.position; //(this.transform.position.x,
		currentCrateLocation.y += offset;
		currentSpawnedAnchorPoint = Instantiate(spawnableAnchorPointPrefab, currentCrateLocation, Quaternion.identity);
		currentSpawnedAnchorPoint.transform.parent = gameObject.transform;
	}    

	public GameObject getSpawnedAnchorPoint()
	{
		return currentSpawnedAnchorPoint;
	}    /*protected override void Start()
   {    }*/
	public override void place(GameObject dropLocation, AnchorPoint anchorPoint)
	{
		this.anchorPoint = anchorPoint;
		gameObject.layer = DEFAULT_LAYER;
		//Debug.Log(dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y));
		//gameObject.transform.localRotation = dropLocation.transform.localRotation;
		gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
		Vector3 currentCrateLocation = this.transform.position; //(this.transform.position.x,
		currentCrateLocation.y += offset;
		//currentCrateLocation.x += 0.5f;
		currentSpawnedAnchorPoint = Instantiate(spawnableAnchorPointPrefab, currentCrateLocation, Quaternion.identity);
		currentSpawnedAnchorPoint.transform.parent = gameObject.transform;
	}    

	public override void pickUp()
	{
		gameObject.layer = IGNORE_RAYCAST_LAYER;        if (currentSpawnedAnchorPoint != null) {
			if (currentSpawnedAnchorPoint.GetComponent<AnchorPoint> ().IsOccupied) {
				return;
			} else {
				Destroy (currentSpawnedAnchorPoint);

				anchorPoint.IsOccupied = false;
				anchorPoint = null;
			}

		} else if (anchorPoint) {
			anchorPoint.IsOccupied = false;
			anchorPoint = null;
		}
	}
}
