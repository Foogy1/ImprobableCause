using UnityEngine;

[RequireComponent(typeof(HeldObject))]
public class PickUpAndMoveBehaviour : MonoBehaviour
{
    /* This class defines the behaviour of the clicking and moving objects.
     * It also signals to the anchor points when to highlight. */
    private HeldObject heldObject;
    private GUIComponents guiComponents;

	private GameObject prevTarget;

	public GameObject heldItem;

    private void Start()
    {
        // Gathers all the anchorPoint components (You do not want to use GetComponent
        // very often).
        heldObject = GetComponent<HeldObject>();
        guiComponents = GetComponent<GUIComponents>();
    }

    private void Update()
    {
        // Pick up object only if the player is not holding another object
        if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() == null)
        {
            pickUpObject();
        }
        // Drops an object if the player is holding an object.
        else if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() != null)
        {
            DropHeldObject();
        }
        // Move held object
        else if (heldObject.getHeldObject())
        {
            moveHeldObject();
        }
        else
        {
            displayObjectText();
        }
    }

    private void pickUpObject()
    {
        RaycastHit hit;
        // Shoot raycast based on mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000))
        {
            GameObject target = hit.transform.gameObject;
			heldItem = target;
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

    private void DropHeldObject()
    {
        RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000))
        {
            GameObject target = hit.transform.gameObject;
            AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
            if (anchorPoint)
            {
                if (anchorPoint.IsOccupied == false && anchorPoint.canObjectBePlacedHere(heldObject.getHeldObject()))
                {
					anchorPoint.removePreviousPlacementHighlight (target);
                    heldObject.placeObject(target);
                    hideAnchorPoints();
					heldItem = null;
                }
            }
        }
    }

    private void moveHeldObject()
    {
        showAnchorPoints();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.transform.gameObject;
			//nullref if what it hits doesn't have an anchor point component - consider checking tags of the hit object
            AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
            if (anchorPoint)
            {
				if (prevTarget != target && prevTarget != null) {
					anchorPoint.removePreviousPlacementHighlight (prevTarget);
				}
                if (anchorPoint.canObjectBePlacedHere(heldObject.getHeldObject()))
                {
                    anchorPoint.showCanBePlaced(target);
                }
                else
                {
                    anchorPoint.showCannotBePlaced(target);
                }
				prevTarget = target;
            }
			heldObject.moveObject(hit.point, heldItem);
        }
    }

    private void displayObjectText()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.transform.gameObject;
            IUsable usable = target.GetComponent<IUsable>();
            if (usable)
            {
                guiComponents.getObjectTypeText().text = usable.getObjectType();
            }
            else
            {
                guiComponents.getObjectTypeText().text = "";
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