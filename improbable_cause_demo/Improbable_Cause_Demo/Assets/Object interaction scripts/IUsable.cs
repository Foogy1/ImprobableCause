using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUsable : MonoBehaviour {
    protected IHolder holder;
    protected bool isPaused = false;
    protected int IGNORE_RAYCAST_LAYER = 2;
    protected int DEFAULT_LAYER = 0;

  

    public void setHolder(IHolder holder)
    {
        this.holder = holder;
    }

    public virtual void pickUp()
    {
        gameObject.layer = IGNORE_RAYCAST_LAYER;
        if (holder)
        {
            holder.removeObject();
            holder = null;
        }
    }


    public virtual void place(GameObject dropLocation)
    {
        gameObject.layer = DEFAULT_LAYER;
        gameObject.transform.position = dropLocation.GetComponent<IHolder>().GetPosition(GetComponent<Renderer>().bounds.size.y);
    }

    public virtual void customAction()
    {

    }


    public virtual void pauseAction()
    {

    }
  
}
