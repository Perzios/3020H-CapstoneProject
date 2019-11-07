using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enables graity on maze floor after some time

public class mazeFloorFall : MonoBehaviour {

    private float timer;
    private int targetTime;

	// Use this for initialization
	void Start () {
        targetTime = Random.Range(7, 48);
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer > targetTime)
        {
            gameObject.SetActive(false);
        }
        if (deactivateMaze.maze == true)
        {
            gameObject.SetActive(true);
        }
	}
}
