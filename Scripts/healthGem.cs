using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Increase player HP if they collide with the health gem

public class healthGem : MonoBehaviour {


    void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerHP> ().incHealth (10);
            Destroy(gameObject);
        }
	}
}
