using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Activates portal that exits level

public class enablePortal : MonoBehaviour {

    public static int count = 0;
    public GameObject altar;
	
	// Update is called once per frame
	void Update () {
        if (count == 2)
        {
            altar.SetActive(true);
        }
	}
}
