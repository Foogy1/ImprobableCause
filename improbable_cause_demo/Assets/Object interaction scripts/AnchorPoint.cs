using UnityEngine;

public class AnchorPoint : MonoBehaviour
{
    /* AnchorPoint class, IUsables will be placed on this object. The side of the object
     * can be specified with the Side enum */
    [Tooltip("Default material")]
    public Material defaultMaterial;

    [Tooltip("Material that will show when an Item can be placed here")]
    public Material canPlaceMaterial;

    [Tooltip("Material that will show when an Item cannot be placed here")]
    public Material cannotPlaceMaterial;

    [Tooltip("Specifies where an object will be placed")]
    public SIDE side;

    private bool isOccupied = false;
	public bool isTransparent = false;
    protected Renderer rend;

	public bool fulcrumReady = false;
	public bool propellerDown = false;

    // This enum represents where an IUsable will be placed when it is dropped on
    // an anchor point.
    public enum SIDE
    {
        FRONT,
        BACK,
        TOP,
        BOTTOM,
    }

 
    // Places object based on position and size.
    public Vector3 GetPosition(float objectSize)
    {
        if (side == SIDE.FRONT)
        {
            return transform.position - transform.right * 1 / 2;
        }
        if (side == SIDE.BACK)
        {
            return transform.position + transform.right * 1 / 2;
        }
        if (side == SIDE.TOP)
        {
            float xPos = transform.position.x;
            float yPos = (transform.position.y) + (objectSize / 2) +
                (GetComponent<Renderer>().bounds.size.y / 2);
            float zPos = transform.position.z;
            return new Vector3(xPos, yPos, zPos);
        }
        if (side == SIDE.BOTTOM)
        {
            return transform.position - transform.up * 1 / 2;
        }
        return new Vector3(0, 0, 0);
    }

    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
        defaultMaterial = GetComponent<Material>();
    }

    public bool IsOccupied
    {
        get { return isOccupied; }
        set { isOccupied = value; }
    }

    public void setObject()
    {
        isOccupied = true;
    }
		
	//made it so the following two functions need a gameobject input (changed in other script)
	//changing the anchor point material to a translucent green
	public void showCanBePlaced(GameObject target)
    {
		Color targetColor = target.GetComponent<Renderer> ().material.color;
		targetColor = Color.green;
		targetColor.a = .5f;
		target.GetComponent<Renderer> ().material.color = targetColor;
       // rend.material = canPlaceMaterial;
    }

	//changing the anchor point material to a translucent red
	public void showCannotBePlaced(GameObject target)
    {
		Color targetColor = target.GetComponent<Renderer> ().material.color;
		targetColor = Color.red;
		targetColor.a = .5f;
		target.GetComponent<Renderer> ().material.color = targetColor;
       // rend.material = cannotPlaceMaterial;
    }

	public void removePreviousPlacementHighlight(GameObject prevTarget){
		if (isTransparent == true) {
			Material prevTargetMaterial = prevTarget.GetComponent<Renderer> ().material;
			prevTargetMaterial.color = Color.clear;
			prevTarget.GetComponent<Renderer> ().material = prevTargetMaterial;
		} else {
			Material prevTargetMaterial = prevTarget.GetComponent<Renderer> ().material;
			prevTargetMaterial = defaultMaterial;
			prevTarget.GetComponent<Renderer> ().material = prevTargetMaterial;
		}
	}

    public bool canObjectBePlacedHere(GameObject go)
    {
        return true;
    }

	private void OnCollisionEnter(Collision otherObjectsCollider){
		if (otherObjectsCollider.gameObject.tag == "Fulcrum") {
			fulcrumReady = true;
		} else if (otherObjectsCollider.gameObject.tag != "AnchorPoint" && otherObjectsCollider.gameObject.tag != "Room") {
			propellerDown = true;
		}
	}
	private void OnCollisionExit(Collision otherObjectsCollider){
		if (otherObjectsCollider.gameObject.tag == "Fulcrum") {
			fulcrumReady = false;
		} else if(otherObjectsCollider.gameObject.tag != "AnchorPoint" && otherObjectsCollider.gameObject.tag != "Room") {
			propellerDown = false;
		}
	}
}