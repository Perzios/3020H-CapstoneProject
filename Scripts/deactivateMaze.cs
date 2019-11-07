using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Disable the maze

public class deactivateMaze : MonoBehaviour {

    private int count;
    public GameObject mazeWalls;
    public GameObject pressurePlates;
    public static bool maze;

	// Use this for initialization
	void Start () {
        count = 0;
        maze = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (count == 2)
        {
            mazeWalls.SetActive(false);
            pressurePlates.SetActive(false);
            maze = true;
            //Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
        }
    }
}
