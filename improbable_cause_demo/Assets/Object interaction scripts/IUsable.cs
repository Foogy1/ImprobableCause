using UnityEngine;

public class IUsable : MonoBehaviour
{
    /* This script should go onto a usable object. It allows the player to pick up
     * and move the object by changing the objects layer from the default to the ignore
     * raycast layer. It also manages which anchor point is "holding" the object */

    protected AnchorPoint anchorPoint;
    protected bool isPaused = false;
    protected int IGNORE_RAYCAST_LAYER = 2;
    protected int DEFAULT_LAYER = 0;

    [Tooltip("Object type label.")]
    public ObjectType objectType;

    public enum ObjectType
    {
        Builder,
        Stacker,
        Jumper,
    }

    public string getObjectType()
    {
        return objectType.ToString();
    }

    public virtual void Start()
    {
    }

    public virtual void pickUp()
    {
        gameObject.layer = IGNORE_RAYCAST_LAYER;
        if (anchorPoint)
        {
            anchorPoint.IsOccupied = false;
            anchorPoint = null;
        }
    }

    public virtual void place(GameObject dropLocation, AnchorPoint anchorPoint)
    {
        this.anchorPoint = anchorPoint;
        gameObject.layer = DEFAULT_LAYER;
        gameObject.transform.position = dropLocation.GetComponent<AnchorPoint>().GetPosition(GetComponent<Renderer>().bounds.size.y);
    }

    public void restart()
    {
    }
}