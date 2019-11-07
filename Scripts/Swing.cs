using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Swings a crate in a pendulum fashion, with random motion

public class Swing : MonoBehaviour {
	private float r, theta, phi;
	private int sign;
	private Vector3 offset, chainOrigin;
	private float minPhi, maxPhi, chainAngle;
	public GameObject chain;
	private GameObject plate;
	// Use this for initialization
	void Start () {
		phi = Mathf.PI * 1.2f;
		theta = 0;
		sign = 1;
		offset = transform.position+2*Vector3.up;
		print ("Swinging");
		r = 2;
		minPhi = 1.2f;
		maxPhi = 1.8f;
		chainOrigin = chain.transform.position + new Vector3 (0, 1, 0);
		chainAngle = 3*Mathf.PI/2;
		//chainOrigin = plate.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dPos = new Vector3 (r * Mathf.Cos (phi), r * Mathf.Sin (phi), 0);//Vector3(r * Mathf.Sin (phi) * Mathf.Sin (theta), r*Mathf.Cos(phi),r * Mathf.Sin (phi) * Mathf.Cos (theta));
		transform.position = offset + dPos;
		chain.transform.position = chainOrigin+dPos/2;
		float deltaPhi = sign*Random.value/30;
		phi += deltaPhi;
		if (phi < Mathf.PI * (minPhi)) {
			sign = 1;
		} else if (phi > Mathf.PI * (maxPhi)) {
			sign = -1;
		}
		theta+=sign*Random.value/5;
		Vector3 delta =  chain.transform.position-transform.position;
		float prevChainAngle = chainAngle;
		chainAngle = Mathf.Atan (delta.x / delta.y);

		chain.transform.rotation = Quaternion.FromToRotation (transform.up, delta);
		chainAngle = Vector3.Angle (Vector3.down, delta);
	}
}
