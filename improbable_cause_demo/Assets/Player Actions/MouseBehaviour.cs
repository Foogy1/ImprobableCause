using UnityEngine;

[RequireComponent(typeof(HeldObject))]
public class MouseBehaviour : MonoBehaviour
{
    /* This class defines the behaviour of the clicking, moving, and rotating objects.
     * It also signals to the anchor points when to highlight. */
    private HeldObject heldObject;
    public GameObject[] anchorPointObject;
    private AnchorPoint[] anchorPoints;

    private void Start()
    {
        // Gathers all the anchorPoint components (You do not want to use GetComponent
        // very often).
        heldObject = GetComponent<HeldObject>();
        for (int i = 0; i < anchorPointObject.Length; i++)
        {
            anchorPoints[i] = anchorPointObject[i].GetComponent<AnchorPoint>();
        }
    }

    private void Update()
    {
        // Pick up object only if the player is not holding another object
        if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() == null)
        {
            RaycastHit hit;
            // Shoot raycast based on mouse position.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000))
            {
                GameObject target = hit.transform.gameObject;
                IUsable usable = target.GetComponent<IUsable>();
                AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
                // If the raycast hit an anchor point, check to make sure the anchor point is not occupied.
                if (anchorPoint)
                {
                    if (anchorPoint.IsOccupied == true)
                    {
                        return;
                    }
                }
                if (usable)
                {
                    heldObject.pickUpObject(target);
                    showAnchorPoints();
                }
            }
        }
        // Drops an object if the player is holding an object.
        else if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000))
            {
                GameObject target = hit.transform.gameObject;
                AnchorPoint holder = target.GetComponent<AnchorPoint>();
                if (holder)
                {
                    if (holder.IsOccupied == false)
                    {
                        heldObject.placeObject(target);
                        hideAnchorPoints();
                    }
                }
            }
        }
        // Move held object
        else if (heldObject.getHeldObject())
        {
            showAnchorPoints();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                heldObject.moveObject(hit.point);
            }
        }
    }

    // highlights anchor points
    private void showAnchorPoints()
    {
        
    }

    // hides all anchor points
    private void hideAnchorPoints()
    {
      
    }
}