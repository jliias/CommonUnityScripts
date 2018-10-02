// ----------------------------------------------------------------------------------------
// SoundManager template. Still to be developed further. 
// Author: Juha Liias, WestSloth Games
// ----------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource fxSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, there can only be one instance of SoundManager (singleton pattern)
			Destroy (gameObject);

		//Set DontDestroyOnLoad so that SoundManager won't be destroyed when reloading scene.
		DontDestroyOnLoad (gameObject);
	}


	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		fxSource.clip = clip;

		//Play the clip.
		fxSource.Play ();
	}
		
}