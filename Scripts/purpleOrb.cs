using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trigger events for orb

public class purpleOrb : MonoBehaviour {

    private int count;
    public static bool open;
    private AudioSource audio;    

	// Use this for initialization
	void Start () {
        count = 0;
        open = false;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(count == 2)
        {
            open = true;
            audio.Play();
        }
        if (count == 2 && audio.isPlaying == false) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magicArrow"))
        {
            count++;
        }
        /*if (other.gameObject.CompareTag("magic")) //check to see if tag right for magic
        {
            count++;
        }*/

    }

    public void openThegate() {
        count++;
    }
}
