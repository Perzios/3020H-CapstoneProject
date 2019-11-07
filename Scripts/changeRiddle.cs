using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changes riddle on flag after the players found the right item

public class changeRiddle : MonoBehaviour {

    public Material riddle2;
    public Material riddle3;
    public Material riddle4;
    public Material riddle5;
    public Material last;
    public static int c = 1;

    public GameObject candle, chair, compass, key, fire;
    public GameObject door;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = door.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (c==2)
        {
            GetComponent<Renderer>().material = riddle2;
        }
        if (c==3)
        {
            GetComponent<Renderer>().material = riddle3;
        }
        if ( c==4)
        {
            GetComponent<Renderer>().material = riddle4;
        }
        if ( c==5)
        {
            GetComponent<Renderer>().material = riddle5;
        }
        if ( c==6)
        {
            GetComponent<Renderer>().material = last;
            animator.SetTrigger("open");
        }
    }
}
