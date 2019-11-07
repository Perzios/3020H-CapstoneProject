using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Opens the gate after the players have hit the runestone

public class removeGate : MonoBehaviour {

    public static bool gateOpen = false;
	
	// Update is called once per frame
	void Update () {
		if(purpleOrb.open == true)
        {
            Destroy(gameObject);
            gateOpen = true;
        }
	}
}
