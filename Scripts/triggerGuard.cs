using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGuard : MonoBehaviour {
	public GameObject guard;
	/**
	*Awakens shreekSkeleton causing it to rush towards the player.
	*/
	void OnTriggerEnter(Collider col){
		guard.GetComponent<ShreekSkeleton> ().awake (col.transform.position);
	}
}
