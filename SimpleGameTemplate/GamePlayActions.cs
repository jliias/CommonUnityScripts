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
	// public, so you can switch it on and off from Unity inspector too
	public bool sceneDone;

	private bool highScoreReady;

	private int score;

	// Use this for initialization
	void Start () {
		sceneDone = false;
		highScoreReady = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Replace following with your gamelogic controls as you wish.
		// You need set sceneDone as 'true' when ready to move next level/scene.
		// Also, highScoreReady boolean is also used here to test GameManager
		// highscore mechanisms
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Ready for next level!");
			if (!sceneDone && !highScoreReady) {
				score =  Random.Range (1, 10);
				// Access variable from GameManager singleton instance
				if (score > GameManager.instance.highScore) {
					GameManager.instance.highScore = score;
					Debug.Log ("highscore: " + GameManager.instance.highScore);
				}
			}
			sceneDone = true;
		}
		// end of block
	}
}
