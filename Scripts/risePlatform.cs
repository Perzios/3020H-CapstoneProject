using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes the skull platform rise up when a player and crate is on the pressure plates

public class risePlatform : MonoBehaviour {

    public float movementSpeed = 1;

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-130, 20, 1);
    private Vector3 currentPos;
    AudioSource sound;
    public static bool DemOnPlat = false;
 
    
    bool pressed = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentPos = transform.position;
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
        if (transform.position != endPosition && pressurePlate.count == 2)
        {

            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
            sound.Play();
            pressed = true;
        }
        else if (pressurePlate.count < 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPos, movementSpeed * Time.deltaTime);
            if (transform.position != currentPos) { sound.Play(); }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Demeter" && endPosition == transform.position) {
            DemOnPlat = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        DemOnPlat = false;
    }
}
