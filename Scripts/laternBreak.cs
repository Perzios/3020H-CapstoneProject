using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Breaks lantern when explode spell is cast on it

public class laternBreak : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlasmaExplosionEffect")
        {
            Destroy(gameObject);
            EnableFlame.LightOn = true;
        }
    }
}
