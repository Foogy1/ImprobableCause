using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour {

    public AudioClip Hit;
	public AudioClip PickUp;
	public AudioClip Topple;
    private AudioSource Source;


    void Start()
    {
    }


    public void PlaySound(GameObject Object)
    {
        Debug.Log("Play sound");
        Source = Object.GetComponent<AudioSource>();
        try
        {
            Source.PlayOneShot(Hit, Random.Range(0.5f, 1.0f));
        }
        catch
        {
            Debug.LogError("You have not attached the Audio Source to the Game Object");
        }
        
    }

	public void PlaySoundPickUp(GameObject Object)
	{
		Debug.Log("Play sound");
		Source = Object.GetComponent<AudioSource>();
		try
		{
			Source.PlayOneShot(PickUp, Random.Range(0.5f, 1.0f));
		}
		catch
		{
			Debug.LogError("You have not attached the Audio Source to the Game Object");
		}

	}

	public void PlaySoundTopple(GameObject Object)
	{
		Debug.Log("Play sound");
		Source = Object.GetComponent<AudioSource>();
		try
		{
			Source.PlayOneShot(Topple, Random.Range(0.5f, 1.0f));
		}
		catch
		{
			Debug.LogError("You have not attached the Audio Source to the Game Object");
		}

	}
}
