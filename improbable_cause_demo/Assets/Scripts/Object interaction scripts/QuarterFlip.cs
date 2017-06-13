using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuarterFlip : MonoBehaviour {

    public AudioClip Quarter;
    private bool flipTime;
    private AudioSource Source;
    // Use this for initialization
    void Start () {
		flipTime = false;
        Source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 20) {
			Debug.Log ("called");
			flipTime = false;
			SceneManager.LoadScene ("WinScene", LoadSceneMode.Single);
		}
		if (flipTime == true) {
			this.transform.Translate (0, .5f, 0, Space.World);
			this.transform.Rotate (0, 0, 30);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log("COINFLIPP");
		IUsable usable = collision.gameObject.GetComponent<IUsable>();
		if (usable) {
			flipTime = true;
            PlayQuarterSound(this.gameObject);
		}
	}

    public void PlayQuarterSound(GameObject Object)
    {
        Debug.Log("Play sound");
        Source = Object.GetComponent<AudioSource>();
        try
        {
            Source.PlayOneShot(Quarter, 1.0f);
        }
        catch
        {
            Debug.LogError("You have not attached the Audio Source to the Game Object");
        }

    }
}
