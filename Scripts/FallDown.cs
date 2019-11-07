using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Determines if create is caught when falling.
 */
public class FallDown : MonoBehaviour {

    private Rigidbody rb;
    public static float x;
    private SoldierSleep guard;
    private bool caught;
    private Vector3 origin;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        guard = GameObject.Find("sleepingGuard").GetComponent<SoldierSleep>();
        caught = false;
        origin = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Physics.gravity.y);
		if(gameObject.transform.parent == null)
        {
            rb.useGravity = true;
            
            //implement here if using magic change gravity speed
        }
        //if (Input.GetKey(KeyCode.L))
        //{
        //    Physics.gravity = new Vector3(0, -6, 0);
        //}
	}

    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.CompareTag("room5Floor") && !caught)
        {
            guard.Awaken(transform.position);
            //x = Physics.gravity.y;
            /*
            if (x == -25)
            {
                guard.Awaken(transform.position);
            }
            else {
                Physics.gravity = new Vector3(0, -25.0f, 0);
            }*/
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("wind") && origin!=transform.position)
        {

            //rb.velocity = Vector3.zero;
            //Physics.gravity = new Vector3(0, -2.0f, 0);
            caught = true;
        }
    }


    
}
