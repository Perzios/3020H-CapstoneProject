using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alerts the light guardif a player is aught in the light

public class lightCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            gameObject.GetComponentInParent<LightGuard>().Awaken(other.transform.position, other.gameObject);
        }
    }
}
