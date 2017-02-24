using UnityEngine;

public class AnchorPoint : MonoBehaviour
{
    /* AnchorPoint class, IUsables will be placed on this object. The side of the object
     * can be specified with the Side enum */

    [Tooltip("Material that will show when an Item is picked up and the point is not occupied.")]
    public Material highlightMaterial;

    [Tooltip("Default material")]
    public Material defaultMaterial;

    [Tooltip("Specifies where an object will be placed")]
    public SIDE side;

    private bool isOccupied = false;
    protected Renderer rend;

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

    public void show()
    {
        rend.material = highlightMaterial;
    }

    public void hide()
    {
        rend.material = defaultMaterial;
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public bool IsOccupied
    {
        get { return isOccupied; }
        set { isOccupied = value; }
    }

    public void setObject()
    {
        isOccupied = true;
        hide();
    }
}