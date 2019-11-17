using UnityEngine;
using System;

public class TestPlayer : MonoBehaviour
{
    // Define event when player is hit
    public static event Action<int> PlayerHit;

    // Update is called once per frame
    void Update()
    {
        // Left mouse button will trigger PlayerHit event
        if (Input.GetMouseButtonDown(0)) {
            PlayerHit(UnityEngine.Random.Range(1, 5));
        }        
    }

}
