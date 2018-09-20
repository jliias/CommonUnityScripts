// Unity3D C# script for shaking camera
// Author: Juha Liias / WestSloth Games 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
	// Camera shake duration and magnitude are made public so
	// they can be finetuned from Unity inspector
	public float shakeTime = 0.3f;
	public float shakeMagnitude = 30f;

	// Variable for storing shake start time (from Time.time method)
	private float startTime;

	// Is shaking on?
	private bool shaking;

	// Camera moving away from it's starting coordinates?
	private bool shakeOut;

	// Vector3 type variable for storing camera start position
	private Vector3 startPosition;

	// Use this for initialization
	void Start ()
	{
		// Store camera starting position
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If camera is shaking
		if (shaking) {
			// Check if shakeTime is already exceeded
			// If not, then continue shaking
			float t = (Time.time - startTime);
			if (t < shakeTime) {
				// Move camera back and forth from starting position in consecutive frames.
				// This is done to prevent camera moving too far from starting position.
				if (shakeOut) {
					// Frame N: Randomize movement for the x and y axis, z position remains unchanged
					transform.Translate (
						Random.Range (-shakeMagnitude, shakeMagnitude) * Time.deltaTime, 
						Random.Range (-shakeMagnitude, shakeMagnitude) * Time.deltaTime,
						0.0f);
					shakeOut = false;
				} else {
					// Frame N+1: return camera to starting point
					transform.position = startPosition;
					shakeOut = true;
				}
			} else {
				// When shaketime is exceeded, stop shaking
				shaking = false;
				shakeOut = false;
				// Restore camera to starting position
				transform.position = startPosition;
			}
		}
	}

	// This function can be called from other Unity script or UI button 
	// using built-in "On Click()" method
	public void StartShake ()
	{
		// Set start time to current system time and activate shaking
		startTime = Time.time;
		shaking = true;
		shakeOut = true;
	}
}
