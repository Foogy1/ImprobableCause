using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollide : MonoBehaviour {

    public GameObject BoxThingy;
    public AudioClip CollideSound;
    private AudioSource SpawnSound;
	// Use this for initialization
	void Start () {
        SpawnSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision coll){
        float vol = Random.Range(0.75f, 1.0f);
        SpawnSound.PlayOneShot(CollideSound, vol);
    }
}
