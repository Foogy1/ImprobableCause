using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldObject : MonoBehaviour {
    GameObject heldObject;
    IHolder holder;
    const float MOVE_SPEED = 4.0f;

    private void Start()
    {
        heldObject = null;
    }

    public GameObject getHeldObject()
    {
        return heldObject;
    }

    public void  moveObject(Vector3 endPosition)
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
        IHolder holder = dropLocation.GetComponent<IHolder>();
         usable.place(dropLocation);
         usable.setHolder(holder);
         holder.setObject();
         heldObject = null;
      
    }

	
}
