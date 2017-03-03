using UnityEngine;

public class GUIComponents : MonoBehaviour
{
    public GameObject objectTypeGameObject;
    private GUIText objectTypeText;

    public GUIText getObjectTypeText()
    {
        return objectTypeText;
    }

    public void Start()
    {
        objectTypeText = objectTypeGameObject.GetComponent<GUIText>();
    }
}