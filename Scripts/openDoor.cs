using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to open door based on given inputs

public class openDoor : MonoBehaviour {

    private Animator animator;
    public GameObject player;
    
    //public RawImage key; //gonna change to inventory box
    public RawImage doorTxt;
    bool press = false;
    private AudioSource sound;

    public bool handle , doIt = false;
    
    public GameObject Doorhandle;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        doorTxt.enabled = false;
        sound = GetComponent<AudioSource>();
        if (handle == false)
        {
            Doorhandle = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (handle) {
            if (Vector3.Distance(player.transform.position, transform.position) < 15 && (player.GetComponentInChildren<Inventory>().getCount("doorHandle") > 0)) {
                doIt = true;
            }
        }
        else if (handle == false) {
            if (Vector3.Distance(player.transform.position, transform.position) < 15 && (player.GetComponentInChildren<Inventory>().getCount("key") > 0)){
                doIt = true;
            }
        }


        if (doIt) { 
            doorTxt.enabled = true;
            
            if (Input.GetKeyUp(KeyCode.B))

            {
                if (handle)
                {
                    Doorhandle.SetActive(true);
                }
                animator.SetTrigger("openDoor");
                sound.Play();
                transform.GetComponent<openDoor>().enabled = false;
                //key.enabled = false;
                doorTxt.enabled = false;
                if (handle)
                {
                    player.GetComponentInChildren<Inventory>().removeSlot("doorHandle");
                }
                else
                {
                    player.GetComponentInChildren<Inventory>().removeSlot("key");
                }
                
            }
        }
        else
        {
            doorTxt.enabled = false;
        }
    }
}
