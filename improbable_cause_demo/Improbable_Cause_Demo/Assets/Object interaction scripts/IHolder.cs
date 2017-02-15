using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHolder : MonoBehaviour {
    public Material highlightMaterial;
    public Material defaultMaterial;

    public bool isOccupied = false;
    protected Renderer rend;
    public SIDE side;

    public enum SIDE
    {
        FRONT,
        BACK,
        TOP,
        BOTTOM,
       
    }

    public Vector3 GetPosition(float blockSize)
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
            float yPos = (transform.position.y) +  (blockSize/2) + 
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
 
    public void removeObject()
    {
        isOccupied = false;
    }

    public void setObject()
    {
        isOccupied = true;
        hide();
    }

    public virtual void Action()
    {
   
    }
}
