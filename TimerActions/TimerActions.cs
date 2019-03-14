using UnityEngine;
using System.Collections;

public class TimerActions : MonoBehaviour {

	// Initialize float type variable for counting time
	public float TimeCounter = 0.0f;

	// Update is called once per frame
	void Update () 
	{
		// Time.deltaTime retuns the time taken to complete the last frame (in seconds)
		TimeCounter += Time.deltaTime;

		// Calculate hours, minutes, and seconds from TimeCounter variable
		// % operator returns the division remainder (e.g. 10 % 3 retuns 1)
		// FloorToInt returns the largest integer that is smaller or equal to given value.
		// So it is basically rounding downwards.
		int hours = Mathf.FloorToInt(TimeCounter / 3600F);
		int minutes = Mathf.FloorToInt((TimeCounter % 3600)/60);
		int seconds = Mathf.FloorToInt(TimeCounter % 60);

		// Format string to be printed so that is prints hours:minutes:seconds (e.g. 01:49:22)
		string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes,seconds);

		// Print formatted string to console using Debug.Log
		Debug.Log(formattedTime);
	}
}
