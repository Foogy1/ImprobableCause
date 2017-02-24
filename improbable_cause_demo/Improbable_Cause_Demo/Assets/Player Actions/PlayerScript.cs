using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeldObject))]
public class PlayerScript : MonoBehaviour {
    HeldObject heldObject;
    public GameObject[] anchorPoints;

  
    // Use this for initialization
    void Start () {
        heldObject = GetComponent<HeldObject>();
	}
	
	// Update is called once per frame
	void Update () {
        // Pick up object
        if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() == null) {
            RaycastHit hit;
            // Shoot raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000))
            {
                GameObject target = hit.transform.gameObject;
                IUsable usable = target.GetComponent<IUsable>();
                IHolder holder = target.GetComponent<IHolder>();
                if (holder)
                {
                    if(holder.isOccupied == true)
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
        // drop an object.
        else if (Input.GetMouseButtonDown(0) && heldObject.getHeldObject() != null)
        {
            RaycastHit hit;
            // Shoot raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000))
            {
                GameObject target = hit.transform.gameObject;
                IHolder holder = target.GetComponent<IHolder>();
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
        else if(heldObject.getHeldObject())
        {
            showAnchorPoints();
            Plane plane = new Plane(Vector3.up, new Vector3(0, 2, 0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                heldObject.moveObject(ray.GetPoint(distance));
            }

        }
   
    }

    void showAnchorPoints()
    {
        foreach(GameObject go in anchorPoints){
            IHolder holder = go.GetComponent<IHolder>();
            if(holder.IsOccupied == false)
            {
                holder.show();
            }
        }
    }

    void hideAnchorPoints()
    {
        foreach (GameObject go in anchorPoints)
        {
            IHolder holder = go.GetComponent<IHolder>();
            if (holder.IsOccupied == false)
            {
                holder.hide();
            }
        }

    }
}
