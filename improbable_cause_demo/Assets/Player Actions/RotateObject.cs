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
        if (Input.GetKeyDown(KeyCode.W))
        {
            float rotation = ((rot.x + ROTATION) % ROTATION) * ROTATION;
           // obj.transform.Rotate(rotation, obj.transform.localEulerAngles.y obj.transform.z);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            float rotation = ((obj.transform.rotation.x - ROTATION) % ROTATION) * ROTATION;
            obj.transform.rotation = new Quaternion(rotation, rot.y, rot.z, rot.w);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            float rotation = ((obj.transform.rotation.z + ROTATION) % ROTATION) * ROTATION;
            obj.transform.rotation = new Quaternion(rotation, rot.y, rot.z, rot.w);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            float rotation = ((obj.transform.rotation.z - ROTATION) % ROTATION) * ROTATION;
            obj.transform.rotation = new Quaternion(rotation, rot.y, rot.z, rot.w);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset object rotation.
            obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
}