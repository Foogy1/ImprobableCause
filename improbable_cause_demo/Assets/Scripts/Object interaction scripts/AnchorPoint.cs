using UnityEngine;

public class AnchorPoint : MonoBehaviour
{
    /* AnchorPoint class, BaseObjects will be placed on this object. The side of the object
     * can be specified with the Side enum */
    [Tooltip("Default material")]
    public Material defaultMaterial;

    [Tooltip("Material that will show when an Item can be placed here")]
    public Material canPlaceMaterial;

    [Tooltip("Material that will show when an Item cannot be placed here")]
    public Material cannotPlaceMaterial;

    [Tooltip("Specifies where an object will be placed")]
    public SIDE side;
    public bool isPropeller = false;
    public bool isOnFulcram = false;
    private bool isOccupied = false;
    protected Renderer rend;

    // This enum represents where an BaseObject will be placed when it is dropped on
    // an anchor point.
    public enum SIDE
    {
        FRONT,
        BACK,
        TOP,
        BOTTOM,
    }

 
    // Places object based on position and size.
    virtual public Vector3 GetPosition(float objectSize)
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

    public virtual void Start()
    {
        rend = GetComponent<Renderer>();
        defaultMaterial = GetComponent<Material>();
    }

    public bool IsOccupied
    {
        get { return isOccupied; }
        set { isOccupied = value; }
    }

    public virtual void setObject()
    {
        isOccupied = true;
    }

    public void showCanBePlaced()
    {
       // rend.material = canPlaceMaterial;
    }

    public void showCannotBePlaced()
    {
       // rend.material = cannotPlaceMaterial;
    }

    public bool canObjectBePlacedHere(GameObject go)
    {
        return true;
    }
}