// ---------------------------------------------------------------------------
// Very simple Unity3D C# script to automatically destroy a particle system
// it is attached to. This is very general-purpose script. 
//
// Author: Juha Liias / WestSloth Games 
// ---------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour 
{
	private ParticleSystem particleSystem;

	public void Start() 
	{
		// Get ParticleSystem type component under this gameobject
		particleSystem = GetComponent<ParticleSystem>();
	}

	public void Update() 
	{
		// Check if particlesystem exists
		if(particleSystem)
		{
			// Destroy particle system when it stops emitting particles
			if(!particleSystem.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}