using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//counts all the artefacts players collect

public class artefacts : MonoBehaviour {


    [SerializeField]
    public static int count = 0;
    public GameObject floor;
    
    public bool fnd = false;

    private void Start()
    {
        floor.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (count == 8  && fnd == false)
        {
            fnd = true;
            floor.SetActive(true);
           
        }
	}

    
}
