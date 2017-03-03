﻿using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private HeldObject heldObject;

    // Use this for initialization
    private void Start()
    {
        heldObject = GetComponent<HeldObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject obj = heldObject.getHeldObject();
        if (!obj) return;
        if (Input.GetKeyDown(KeyCode.W))
        {
            obj.transform.Rotate(obj.transform.rotation.x + 45, obj.transform.rotation.y, obj.transform.rotation.z);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            obj.transform.Rotate(obj.transform.rotation.x - 45, obj.transform.rotation.y, obj.transform.rotation.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            obj.transform.Rotate(obj.transform.rotation.x, obj.transform.rotation.y, obj.transform.rotation.z + 45);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            obj.transform.Rotate(obj.transform.rotation.x, obj.transform.rotation.y, obj.transform.rotation.z - 45);
        }
    }
}