using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls effect of the locked up dragon

public class Dragon : MonoBehaviour {

    private AudioSource sound;
    public GameObject player1;
    public GameObject player2;
    public ParticleSystem ps;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sound.isPlaying == false) {
            if (Vector3.Distance(player1.transform.position, transform.position) < 20 || Vector3.Distance(player2.transform.position, transform.position) < 20)
            {
                sound.Play();
                ps.Play();
            }
        }   
    }
}
