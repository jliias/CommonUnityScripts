// -----------------------------------------------------------------------------------------
// Loader class for instantiating GameManager and SoundManager for game (singleton pattern).
// This must be placed in some GameObject (e.g. Camera) at first scene (buildIndex=0).
// Author: Juha Liias, WestSloth Games
// -----------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour 
{
	public GameObject gameManager;          //GameManager prefab to instantiate.
	public GameObject soundManager;         //SoundManager prefab to instantiate.


	void Awake ()
	{
		//Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		if (GameManager.instance == null)

			//Instantiate gameManager prefab
			Instantiate(gameManager);

		//Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
		if (SoundManager.instance == null)

			//Instantiate SoundManager prefab
			Instantiate(soundManager);
	}
}
