using UnityEngine;
using System.Collections;

public class ShareApp : MonoBehaviour
{
 
	// Subject line
	private string subject = "Simple Template for Game!";

	// Varible for body text to share
	private string body;

	public void shareText ()
	{
		// Select body text
		selectBodyText ();

		Debug.Log ("Sharing:\n" + body);

		//execute the below lines if running on a Android device
		#if UNITY_ANDROID
		// Reference of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		// Reference of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		// call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		// set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
		// add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), body);
		// get the current activity
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		// start the activity by sending the intent data
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, "Share Via");
		currentActivity.Call ("startActivity", jChooser);
		// currentActivity.Call ("startActivity", intentObject);
		#endif
     
	}

	// Method for creating bodytext to share
	// This example has total of 5 different texts, but you can do whatever you want.
	void selectBodyText ()
	{
		int selection = Random.Range (0, 5);
		switch (selection) {
		case 0: 
			body = "Can you beat me in this funny #hypercasual #indiegame? Get it for #Android!";
			break;
		case 1:
			body = "Blaa blaa blaa...replace with your favorite slogan!";
			break;
		case 2:
			body = "Woohoo! Going hyper-casual with this #challenging and hard-to-master #mobilegame! Get it for Android!";
			break;
		case 3:
			body = "Simple, addictive and much harder than it looks! #hypercasual #indiegames #android #gamedev";
			break;
		case 4:
			body = "Hyper-Casual - Ultra-Challenging - Super-Fun!\nYou will need extreme concentration to succeed!\n#hypercasual #indiegames #madewithunity";
			break;
		default:
			body = "Default sentence in case something goes wrong!";
			break;
		}
		Debug.Log (body);
	}
 
}
