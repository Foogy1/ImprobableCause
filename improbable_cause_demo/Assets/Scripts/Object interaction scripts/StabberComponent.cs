using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StabberComponent : Component
{
    public GameObject stabberParent;

    bool stabbed = false;
    private GameObject stabbingObject;

	protected override void Start ()
	{
        base.Start();
	}

    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != stabberParent && !stabbed)
        {
            collision.gameObject.AddComponent<FixedJoint>();
            collision.gameObject.GetComponent<FixedJoint>().connectedBody = GetComponent<Rigidbody>();
            stabbingObject = collision.gameObject;
            stabbed = true;
        }
    }

    public void Restart()
    {
        if (stabbingObject.GetComponent<FixedJoint>())
            Destroy(stabbingObject.GetComponent<FixedJoint>());
        stabbingObject = null;
        stabbed = false;
    }
}
