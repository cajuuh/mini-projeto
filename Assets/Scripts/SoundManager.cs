using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//Object variables
	public AudioSource sfx;
	public AudioSource music;

	//Static variables;
	public static SoundManager instance = null;

	void Awake(){
		if(instance == null){
			instance = this;

		}else if(instance != this){
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip audio){
		sfx.clip = audio;
		sfx.Play();

	}
}
