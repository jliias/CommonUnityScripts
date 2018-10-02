// ----------------------------------------------------------------------------------------
// GamePlayActions template
// To be filled with gamelogic controls etc. 
// Author: Juha Liias, WestSloth Games
// ----------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayActions : MonoBehaviour {

	// Set this true when ready to switch to next scene
	public bool sceneDone;

	// Use this for initialization
	void Start () {
		sceneDone = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Replace following with your gamelogic controls as you wish
		// You need set sceneDone as 'true' when ready to move next level/scene
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Ready for next level!");
			sceneDone = true;
		}
		// end of block
	}
}
