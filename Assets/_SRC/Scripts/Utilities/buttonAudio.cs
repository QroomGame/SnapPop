using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAudio : MonoBehaviour {

    AudioSource soundFX;
    public AudioClip[] soundByte;

    public void PlaySound(int a)
    {
        soundFX.clip = soundByte[a];
        soundFX.Play();
    }

    // Use this for initialization
    void Start () {
        soundFX = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
