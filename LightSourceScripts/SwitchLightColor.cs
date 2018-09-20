// ---------------------------------------------------------------------------
// Unity3D C# script for changing the color of any light source in defined
// interval. Attach this script to an object containing light source. 
//
// Author: Juha Liias / WestSloth Games 
// ---------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightColor : MonoBehaviour
{
	// Variable to store ínterval for changing color (unit: seconds)
	// Make this public, if willing to tune interval from inspector
	private float triggerLimit;

	// Variable to store starting time (system time using Time.time)
	private float startTime;

	// Light object should be child of GameObject where this script is attached
	private Light thisLight;

	// Use this for initialization
	void Start ()
	{
		// Find Light type component under current gameobject
		thisLight = GetComponent<Light> ();

		// set starting color as green
		thisLight.color = Color.green;

		// Initialize startTime
		this.startTime = Time.time;

		// Set triggerLimit to carefully selected float value. 
		// Comment following line, if triggerLimit is public and set from inspector
		triggerLimit = 0.42f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Change Light color in intervals defined by triggerLimit variable
		if (Time.time - startTime > triggerLimit) {
			Debug.Log ("flash!");
			// Randomly select next color using Random.Range() and switch-case
			int nextColor = Random.Range (0, 4);
			Color myColor;
			switch (nextColor) {
			case 0:
				myColor = Color.red;
				break;
			case 1:
				myColor = Color.green;
				break;
			case 2: 
				myColor = Color.blue;
				break;
			case 3:
				myColor = Color.white;
				break;
			default:
				Debug.Log ("something went wrong...");
				myColor = Color.white;
				break;
			}

			// Change light color
			thisLight.color = myColor;

			// Initialize startTime again
			this.startTime = Time.time;
		}
	}
}
