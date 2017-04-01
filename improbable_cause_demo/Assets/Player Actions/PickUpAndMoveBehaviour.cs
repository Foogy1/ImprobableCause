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
        else if (heldObject.getHeldObject())
        {
            Topple topple = heldObject.getHeldObject().GetComponent<Topple>();
            moveHeldObject();
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentRot = this.gameObject.transform.localRotation;
               // Debug.Log(currentRot);
                heldObject.getHeldObject().transform.Rotate(currentRot.x, currentRot.y + 45, currentRot.z, Space.World);
                if (topple)
                {
                    topple.SetTargetRotation(gameObject.transform.localRotation);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentRot = this.gameObject.transform.rotation;
                heldObject.getHeldObject().transform.Rotate(currentRot.x, currentRot.y - 45, currentRot.z, Space.World);
                if (topple) { 
                topple.SetTargetRotation(gameObject.transform.localRotation);
                   }
            }
        }
        else
        {
            displayObjectText();
        }
    }

    private void pickUpObject()
    {
        RaycastHit hit;
        //   int layerMask = LayerMask.GetMask("AnchorPoint");
        // Shoot raycast based on mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000))
        {
            GameObject target = hit.transform.gameObject;
            IUsable usable = target.GetComponent<IUsable>();
            AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
            Stackable stackable = target.GetComponent<Stackable>();
            // If the raycast hit an anchor point, check to make sure the anchor point is not occupied.
            if (stackable)
            {
                if (stackable.getSpawnedAnchorPoint() != null)
                {
                    if (stackable.getSpawnedAnchorPoint().GetComponent<AnchorPoint>().IsOccupied == true)
                    {
                        Debug.Log("IsOCcupied");
                        return;
                    }
                }

                Debug.Log("picking up object");
                heldObject.pickUpObject(target);
                showAnchorPoints();

            }
            else if (usable)
            {
                if(target.GetComponent<Topple>() != null)
                {
                    usable.ResetRotation();
                }
                heldObject.pickUpObject(target);
                showAnchorPoints();
            }
        }
    }

    void pickup() { }

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
                    heldObject.placeObject(target);
                    hideAnchorPoints();
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
            AnchorPoint anchorPoint = target.GetComponent<AnchorPoint>();
            if (anchorPoint)
            {
                if (anchorPoint.canObjectBePlacedHere(heldObject.getHeldObject()))
                {
                    anchorPoint.showCanBePlaced();
                }
                else
                {
                    anchorPoint.showCannotBePlaced();
                }
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
            IUsable usable = target.GetComponent<IUsable>();
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

    // highlights anchor points
    private void showAnchorPoints()
    {

    }

    // hides all anchor points
    private void hideAnchorPoints()
    {

    }
}