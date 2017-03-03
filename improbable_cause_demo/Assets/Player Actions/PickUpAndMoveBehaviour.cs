﻿using UnityEngine;

[RequireComponent(typeof(HeldObject))]
public class PickUpAndMoveBehaviour : MonoBehaviour
{
    /* This class defines the behaviour of the clicking and moving objects.
     * It also signals to the anchor points when to highlight. */
    private HeldObject heldObject;
    public GameObject[] anchorPointObject;
    private AnchorPoint[] anchorPoints;
    private GUIComponents guiComponents;

    private void Start()
    {
        // Gathers all the anchorPoint components (You do not want to use GetComponent
        // very often).
        heldObject = GetComponent<HeldObject>();
        guiComponents = GetComponent<GUIComponents>();
        anchorPoints = new AnchorPoint[anchorPointObject.Length];
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
        foreach (AnchorPoint ap in anchorPoints)
        {
            if (ap.IsOccupied == false)
            {
                ap.show();
            }
        }
    }

    // hides all anchor points
    private void hideAnchorPoints()
    {
        foreach (AnchorPoint ap in anchorPoints)
        {
            if (ap.IsOccupied == false)
            {
                ap.hide();
            }
        }
    }
}