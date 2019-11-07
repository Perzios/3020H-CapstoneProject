using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Shreek skeleton rushes towards player from a dark corner inflicting damage.
 */
public class ShreekSkeleton : MonoBehaviour {
	private Vector3 dest;
	public float speed;
	private Vector3 heading;
	private bool sleep = true;
	private Animator anim;
	public int damage;
	private AudioSource scream;

	// Use this for initialization
	void Start () {
		heading = Vector3.zero;
		dest = Vector3.zero;
		anim = gameObject.GetComponentInChildren<Animator> ();
		scream = gameObject.GetComponent<AudioSource> ();
	}

	public void awake(Vector3 pos){
		sleep = false;
		if (heading == Vector3.zero) {
			heading = pos - transform.position;
			dest = transform.position + heading * 50;
		}
		if (PlayerPrefs.GetInt("sound",1)==1){
			scream.Play();
		}
		anim.SetBool ("isMove", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == dest) {
			Destroy (gameObject);
		}
		if (!sleep) {
			transform.position += (heading * speed *0.09f);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			col.GetComponent<PlayerHP> ().incHealth (damage);
		}
	}
}
