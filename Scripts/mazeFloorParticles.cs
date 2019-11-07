using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Plays particle effect on maze floor

public class mazeFloorParticles : MonoBehaviour {

    private ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (deactivateMaze.maze)
        {
            ps.Play();
        }
	}
}
