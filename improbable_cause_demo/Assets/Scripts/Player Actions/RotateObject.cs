using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float ROTATION = 45.0f;
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
        Quaternion rot = obj.transform.rotation;
        if (Input.GetKeyDown(KeyCode.A))
        {
            float rotation = ((obj.transform.rotation.z + ROTATION) % ROTATION) * ROTATION;
            obj.transform.Rotate(transform.rotation.x, rotation , transform.rotation.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            float rotation = ((obj.transform.rotation.z - ROTATION) % ROTATION) * ROTATION;
            obj.transform.Rotate(transform.rotation.x, rotation, transform.rotation.z);
        }
       
    }
}