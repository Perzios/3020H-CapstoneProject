using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Parent class for sentry, soldier, sleep guard, light guard and shriek skeleton.
//COntains common scripts shares amount NPCs

public class Enemy : MonoBehaviour {
	public GameObject [] players;
	public enum State {Awake, Search, Chase, Sleep, Alerted, Attack};
	public State current;
	public float damage;//Should be negative

	public GameObject[] getPlayers(){
		return GameObject.FindGameObjectsWithTag ("Player");

	}

	public Vector3 getClosestPlayer(){
		return getClosest ().transform.position;
	}

	//Returns the closest player location
	public GameObject getClosest(){
		players = getPlayers ();
		float closest = float.PositiveInfinity;
		GameObject player = players [0];			
		for (int i = 0; i < players.Length; ++i) {
			float dist = Vector3.Magnitude (players [i].transform.position - transform.position);
			if (dist < closest) {
				closest = dist;
				player = players [i];

			}
		}
		return player;
	}

	//Return player position + "fuzz" factor
	public Vector3 getPlayerPos(){
		Vector3 pos = getClosestPlayer ();
		float dist = Vector3.Magnitude (transform.position)/10;
		Vector3 fuzz =new Vector3(Random.Range (-dist, dist),Random.Range (-dist, dist),Random.Range (-dist, dist));
		return  pos+ fuzz;
	}

	//Check Player visible
	public GameObject checkPlayer(){
		if (Vector3.Magnitude(getClosestPlayer() - transform.position)<2) {
			return getClosest ();
		}

		//raycast for player
		RaycastHit hit;
		Vector3 axis = Vector3.Cross (Vector3.up, transform.forward);
		Vector3[] dir = new Vector3[5];
		Vector3 origin = transform.position + Vector3.up *4;
		dir[0]= transform.forward;
		dir[1]= Quaternion.AngleAxis (10, Vector3.up)*transform.forward;
		dir[2]= Quaternion.AngleAxis (-10, Vector3.up)*transform.forward;
		dir [3] = Quaternion.AngleAxis (20, axis) * transform.forward;
		dir [4] = Quaternion.AngleAxis (-20, axis) * transform.forward;

		//DEBUG
		Debug.DrawRay (origin, dir[1]*25, Color.red);
		Debug.DrawRay (origin, dir[0]*25, Color.green);
		Debug.DrawRay (origin, dir[2]*25, Color.red);
		Debug.DrawRay (origin, dir[3]*25, Color.blue);
		Debug.DrawRay (origin, dir[4]*25, Color.blue);

		for (int i = 0; i < 5; ++i) {
			if (Physics.SphereCast (origin, 3, dir[i], out hit, 25)) {
				if (hit.collider.tag == "Player") {
					return hit.collider.gameObject;
				}
				print (hit.collider.tag);
			}
		}

		return gameObject;
	}

	public void doDamage(GameObject player){
		Debug.Log ("Damage"+" "+player.name);
        PlayerHP pHealth = player.GetComponent<PlayerHP> ();
		if (pHealth == null) {
			pHealth = player.GetComponentInParent<PlayerHP> ();
		}
		if (pHealth) {
			Debug.Log ("Damage"+" inflicted on "+player.name);
			pHealth.incHealth (damage);
		} else {
			
			pHealth = player.GetComponentInParent<PlayerHP> ();
			if (pHealth) {
				pHealth.incHealth (damage);
			} else {
				print ("Miss on "+player.name);
			}
		}
	}
	

}
