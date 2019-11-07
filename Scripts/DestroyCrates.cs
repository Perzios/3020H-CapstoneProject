using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys crate

public class DestroyCrates : MonoBehaviour {

    void Start()
    {
        StartCoroutine("Breakdown");
    }

    IEnumerator Breakdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
