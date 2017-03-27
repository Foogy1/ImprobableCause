using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour {

    public AudioClip Hit;
    private AudioSource Source;


    void Start()
    {
    }


    public void PlaySound(GameObject Object)
    {
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
}
