// ----------------------------------------------------------------------------------------
// GameManager class:
// - Handles transitions between Unity scenes
//
// Author: Juha Liias, WestSloth Games
// ----------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

// Allows to use UI components
using UnityEngine.UI;

// Allows to use scenemanagement components
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null;

	// Need to access at least some variables from GamePlay type instance
	private GamePlayActions gamePlayActions;

	// current scene number
	private int sceneNumber;

	// Highscore as integer
	public int highScore;

	// use this as PlayerPrefs 
	public string highScoreKey = "LocalHighScore";

	// Text to display current level number
	// (not necessary same than current scene)
	private Text textLevel;

	// Text to display continue message for player
	// Gameobject variable is needed for show/hide text
	private GameObject continueObject;
	private Text textContinue;
	private string continueMessage = "Tap to continue";

	// GameObject for menu button
	private GameObject buttonMenu;

	// Text to display highscore on menu screen
	// GameObject variable is needed for show/hide text
	private GameObject highScoreObject;
	private Text textHighScore;
	private string highScoreMessage;

	// Awake is always called before any Start functions
	void Awake ()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		// If instance already exists and it's not this
		else if (instance != this)
			//Then destroy this. There can only ever be one instance of a GameManager (singleton pattern)
			Destroy (gameObject); 

		//Sets this to not be destroyed when loading scene
		DontDestroyOnLoad (gameObject);

		//Call the InitGame function to initialize the first scene (0) 
		InitGame (0);
	}

	// Will be called right after "Awake"
	private void OnEnable ()
	{
		// Add delegate to this when a scene is loaded
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	// Will be called when game is terminated
	private void OnDisable ()
	{
		// unsubscribe delegate
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	//Update is called every frame.
	void Update ()
	{
		// Check active scene and get it's buildIndex (integer)
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneNumber = currentScene.buildIndex;

		// Continue to next scene (buildIndex), if:
		//   mouse is clicked AND
		//       GamePlayActions type object does not exist on current scene (menu or init scene)
		//    OR GamePlayActions.sceneDone variable is true (scene is completed)
		if (Input.GetMouseButtonDown (0) && !MyIsPointerOverGameObject ()) {
			if (continueObject != null) {
				continueObject.SetActive (true);
			}
			if (buttonMenu != null) {
				buttonMenu.SetActive (true);
			}
			if (gamePlayActions == null || gamePlayActions.sceneDone) {
				Debug.Log ("mouse button on level:" + sceneNumber);
				NextScene ();
			}
		}
	}


	// This will be executed when scene is loaded
	private void OnSceneLoaded (Scene thisScene, LoadSceneMode mode)
	{
		// Get active scene and pass it's buildIndex to InitGame
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneNumber = currentScene.buildIndex;
		InitGame (sceneNumber);
	}

	// Initializes the game for each level.
	// Level 0 : initialize and start GameManager
	// Level 1 : Menu screen
	// Level indexes >2 are game levels by default when using this script
	void InitGame (int scene)
	{
		Debug.Log ("Initializing level: " + scene);

		// Try to find GamePlayActions type object from current scene
		// (mandatory for actual game levels)
		gamePlayActions = GameObject.FindObjectOfType<GamePlayActions> ();

		// Search for TextLevel named UI object
		// If found, set Text content as "Level: <n>"
		GameObject textObject = GameObject.Find ("TextLevel");
		Debug.Log ("textobject: " + textObject);
		if (textObject != null) {
			textLevel = textObject.GetComponent<Text> ();
			textLevel.text = "Level: " + (scene - 1);
		}

		// Search for TextContinue
		// If found, set Text content as continueMessage
		continueObject = GameObject.Find ("TextContinue");
		if (continueObject != null) {
			textContinue = continueObject.GetComponent<Text> ();
			textContinue.text = continueMessage;
			continueObject.SetActive (false);
		}

		buttonMenu = GameObject.Find ("ButtonMenu");
		if (buttonMenu != null) {
			buttonMenu.SetActive (false);
		}

		highScoreObject = GameObject.Find ("HighScoreText");
		if (highScoreObject != null) {
			highScoreMessage = "Highscore\n" + highScore;
			textHighScore = highScoreObject.GetComponent<Text> ();
			textHighScore.text = highScoreMessage;
			highScoreObject.SetActive (true);
		}
	}
		
	// Returns true if mouse or first touch is over any event system object (usually gui elements)
	public static bool MyIsPointerOverGameObject ()
	{
		//check mouse
		if (EventSystem.current.IsPointerOverGameObject ())
			return true;

		//check touch
		if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began) {
			if (EventSystem.current.IsPointerOverGameObject (Input.touches [0].fingerId))
				return true;
		}
		return false;
	}
		
	// Switch to next active scene
	// If this is the last scene (buildIndex), then jump back to menu scene ('1' by default)
	private void NextScene ()
	{
		int nextScene;
		if (sceneNumber <= SceneManager.sceneCount + 1) {
			nextScene = sceneNumber + 1;
		} else {
			nextScene = 1;
		}
		Debug.Log ("next scene: " + nextScene);
		SceneManager.LoadScene (nextScene);
	}

	// Method for loading menu scene (buildIndex = 1)
	// Will be called by "menu" button in template
	public void LoadMenu ()
	{
		int nextScene = 1;
		Debug.Log ("next scene: " + nextScene);
		SceneManager.LoadScene (nextScene);
	}

	public int LoadHighScore() {
		int thisHighScore = PlayerPrefs.GetInt (highScoreKey, 0);
		return thisHighScore;
	}

	public void SaveHighScore(int thisScore) {
		PlayerPrefs.SetInt (highScoreKey, thisScore);
	}
}
