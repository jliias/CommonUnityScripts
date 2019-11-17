/* Manager class for testing events using Actions
 * Author: Juha Liias, WestSloth Games
 */
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Awake is called after all objects are initialized
    private void Awake()
    {
        // Subscribe PlayerHit event
        TestPlayer.PlayerHit += GetDamage;
    }

   // GetDamage is called when PlayerHit event is detected 
    private void GetDamage(int damage) {
        Debug.Log("Got " + damage + " damage!");
        // Do something when player is getting damage
        // add your actions here
    }

    // OnDisable is called when behavior becomes disabled
    private void OnDisable()
    {
        // UnSubscribe to avoid memory leak
        TestPlayer.PlayerHit -= GetDamage;
    }
}

