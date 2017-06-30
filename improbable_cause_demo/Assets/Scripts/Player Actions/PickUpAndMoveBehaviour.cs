using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HeldObject))]
public class PickUpAndMoveBehaviour : MonoBehaviour
{
    /* This class defines the behaviour of the clicking and moving objects.
     * It also signals to the anchor points when to highlight. */
    private HeldObject heldObject;
    public GameObject image;
    public GameObject text;
    public GameObject textBG;
    private Text description;
    private Text objectTypeText;
    private Image backgroundImage;
    private Quaternion currentRot;
    private AnchorPoint anchorPoint;

    private void Start()
    {
        // Gathers all the anchorPoint components (You do not want to use GetComponent
        // very often).
        heldObject = GetComponent<HeldObject>();
        objectTypeText = image.GetComponentInChildren<Text>();
        objectTypeText.text = "";
        description = text.GetComponent<Text>();
        description.text = "";
        backgroundImage = image.GetComponent<Image>();
        backgroundImage.enabled = false;
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
        else if (heldObject.getHeldObject() != null)
        {
            moveHeldObject();
            heldObject.getHeldObject().GetComponent<BaseObject>().isHeld = true;
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
            BaseObject usable = target.GetComponent<BaseObject>();
            AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
            StackableComponent stackable = target.GetComponent<StackableComponent>();
            // If the raycast hit an anchor point, check to make sure the anchor point is not occupied.
            if (stackable)
            {
                if (stackable.getSpawnedAnchorPoint() != null)
                {
                    if (stackable.getSpawnedAnchorPoint().GetComponent<AnchorPoint>().IsOccupied == true)
                    {
                        return;
                    }
                }
                heldObject.pickUpObject(target);
            }
            else if (usable)
            {
                heldObject.pickUpObject(target);
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
            AnchorPoint CurrAnchorPoint = target.GetComponent<AnchorPoint>();
            if (CurrAnchorPoint)
            {
                if (CurrAnchorPoint.IsOccupied == false && CurrAnchorPoint.canObjectBePlacedHere(heldObject.getHeldObject()))
                {
                    heldObject.getHeldObject().GetComponent<BaseObject>().isHeld = false;

                    heldObject.placeObject(target);
                }
            }
        }
    }

    private void moveHeldObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.transform.gameObject;
            AnchorPoint CurrAnchorPoint = target.GetComponent<AnchorPoint>();
            if (anchorPoint)
            {
                //  anchorPoint.showDefaultMaterial();
            }
            if (CurrAnchorPoint)
            {
                if (CurrAnchorPoint.canObjectBePlacedHere(heldObject.getHeldObject()))
                {
                    //     CurrAnchorPoint.showCanBePlaced();
                }
                else
                {
                    ///  CurrAnchorPoint.showCannotBePlaced();
                }
                anchorPoint = CurrAnchorPoint;
            }
            heldObject.moveObject(hit.point);
        }
    }

    private void displayObjectText()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.transform.gameObject;
            BaseObject usable = target.GetComponent<BaseObject>();
            if (usable)
            {
                description.text = usable.GetDescription();
                objectTypeText.text = usable.getObjectType();
                backgroundImage.enabled = true;
            }
            else
            {
                description.text = "";
                objectTypeText.text = "";
                backgroundImage.enabled = false;
            }
        }
    }
}