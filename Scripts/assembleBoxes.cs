using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Global values for dropping crates. Used to start convergance of crates

public class assembleBoxes : MonoBehaviour {

    public static int count;
    public static int count2;
    public static bool fell;
    public static bool start;

    // Use this for initialization
    void Start () {
        count = 0;
        count2 = 0;
        fell = false;
        start = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(count2 == 7)
        {
            start = true;
        }
        
    }

   
}
