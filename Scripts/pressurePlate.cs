using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lowers preasureplate when object stands on it

public class pressurePlate : MonoBehaviour {

    public static int count;

	// Use this for initialization
	void Start () {
        count = 0;
	}

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale -= new Vector3(0, 0.2f, 0);
        collision.transform.position -= new Vector3(0,0.2f,0);
        count++;
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.localScale += new Vector3(0, 0.2f, 0);
        collision.transform.position += new Vector3(0, 0.2f, 0);
        count--;
    }
}
