using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    public Button leftButton;
    public Button rightButton;
    public GameObject mainCamera;
    public Vector3 centerPosition = new Vector3(0, 0, 0);
    public AudioClip ButtonSound;

    OutlineSystem outlineSys;
    int index = 1;
    AudioSource Source;


    void Start ()
    {
        leftButton.onClick.AddListener(() => MoveLeft());
        rightButton.onClick.AddListener(() => MoveRight());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveRight();
        }
    }


    void MoveLeft()
    {
        index--;
        if (index < 0)
        {
            index = 0;
        }
        else
            mainCamera.transform.RotateAround(centerPosition, Vector3.up, 33f);

        PlayButtonSound(this.gameObject);
    }

    void MoveRight()
    {
        index++;
        if (index > 2)
        {
            index = 2;
        }
        else
            mainCamera.transform.RotateAround(centerPosition, Vector3.up, -33f);

        PlayButtonSound(this.gameObject);

    }

    public void PlayButtonSound(GameObject Object)
    {
        Debug.Log("Play sound");
        Source = Object.GetComponent<AudioSource>();
        try
        {
            Source.PlayOneShot(ButtonSound, 1.0f);
        }
        catch
        {
            Debug.LogError("You have not attached the Audio Source to the Game Object");
        }

    }
}
