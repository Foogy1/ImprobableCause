using UnityEngine;

public class Stackable : AnchorPoint
{
    /* Iusables can be placed on this object */

    private void Start()
    {
        side = SIDE.TOP;
        rend = GetComponent<Renderer>();
    }
}