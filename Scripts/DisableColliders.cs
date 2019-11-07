using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour {

    public static bool block;

	// Use this for initialization
	void Start () {
        block = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (block == false)
        {
            Destroy(gameObject);
        }
	}
}
