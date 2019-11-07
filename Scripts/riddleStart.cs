using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Starts the riddle puzzle

public class riddleStart : MonoBehaviour {

    public static bool riddleRoom = false;

	

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            riddleRoom = true;
        }
    }
}
