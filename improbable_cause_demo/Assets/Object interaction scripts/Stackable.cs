using UnityEngine;

public class Stackable : AnchorPoint
{
    /* IUsables can be placed on this object */

    protected override void Start()
    {
        side = SIDE.TOP;
        rend = GetComponent<Renderer>();
    }
}