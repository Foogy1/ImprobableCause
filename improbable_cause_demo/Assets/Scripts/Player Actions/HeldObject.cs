using UnityEngine;

public class HeldObject : MonoBehaviour
{
    /* This script defines the behaviour of the Held Object. It manages picking
     * up and placing objects and signaling to anchor points that an object has
     * been picked up or place */
    private GameObject heldObject;
    private AnchorPoint anchorPoint;

    private void Start()
    {
        heldObject = null;
    }

    public GameObject getHeldObject()
    {
        return heldObject;
    }

    public void moveObject(Vector3 endPosition)
    {
        heldObject.transform.position = endPosition;
    }

    public void pickUpObject(GameObject gameObject)
    {
        heldObject = gameObject;
        heldObject.GetComponent<IUsable>().pickUp();
    }

    public void placeObject(GameObject dropLocation)
    {
        IUsable usable = heldObject.GetComponent<IUsable>();
        AnchorPoint anchorPoint = dropLocation.GetComponent<AnchorPoint>();
        usable.place(dropLocation, anchorPoint);
        anchorPoint.setObject();
        heldObject = null;
    }
}