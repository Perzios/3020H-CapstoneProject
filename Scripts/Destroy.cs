using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy game object after time period

public class Destroy : MonoBehaviour {

    public float val = 1.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject,val);
	}
	
}
