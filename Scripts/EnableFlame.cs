using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Activates flame

public class EnableFlame : MonoBehaviour {

    public static bool LightOn = false;

    // Update is called once per frame
    void Update () {
        if (LightOn)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
	}
}
