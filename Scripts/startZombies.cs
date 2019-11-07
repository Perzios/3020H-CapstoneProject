using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enable the zombie spawner in room 10

public class startZombies : MonoBehaviour {

    public GameObject zombies;
    public static bool start = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            start = true;
            zombies.SetActive(true);
            Destroy(gameObject);
        }
    }
}
