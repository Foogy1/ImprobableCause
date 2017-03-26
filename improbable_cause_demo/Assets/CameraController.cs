using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    public Button leftButton;
    public Button rightButton;
   private  Camera mainCamera;
    public GameObject left;
    public GameObject right;
    private Camera leftCamera;
    private Camera rightCamera;
    private Camera[] cameras;
    private Camera currCamera;
    private int current = 1;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponentInChildren<Camera>();
        currCamera = mainCamera;
        leftCamera = left.GetComponent<Camera>();
        leftCamera.enabled = false;
        rightCamera = right.GetComponent<Camera>();
        rightCamera.enabled = false;
        cameras = new Camera[] { leftCamera, mainCamera, rightCamera };

        leftButton.onClick.AddListener(() => MoveLeft());
        rightButton.onClick.AddListener(() => MoveRight());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)){
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveRight();
        }

    }


    void MoveLeft()
    {
        current--;
        if (current < 0)
        {
            current = 0;
        }
        currCamera.enabled = false;
        cameras[current].enabled = true;
        currCamera = cameras[current];
    }

    void MoveRight()
    {
        current++;
        if (current > 2)
        {
            current = 2;
        }
        currCamera.enabled = false;
        cameras[current].enabled = true;
        currCamera = cameras[current];

    }
}
