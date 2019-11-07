using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Controls behaviour of brute type enemies
//Inherets from enemy
//Responds to alert from Sentries

public class Soldier : Enemy {
	private NavMeshAgent agent;
	private bool seen ;
	private Vector3 dest, signalDest, prevSignal;
	private Random rand;
	private float searchTimer;
	private GameObject[] enemies;
	private GameObject target;
	private Animator anim;
    public int intial;

    //Called by sentry to alert soldier to players presents
    public void Awaken(Vector3 playerPos){
		if (Vector3.Magnitude(getClosestPlayer() - transform.position) < 20) {
			current = State.Awake;
		}

		current = State.Chase;
		if (Vector3.Magnitude (dest - transform.position) > Vector3.Magnitude (playerPos - transform.position)) {
			agent.destination = playerPos;
			anim.SetBool ("run 0", true);
		}
		signalDest = playerPos;
	}

	// Use this for initialization
	private void Start () {
		agent = GetComponent<NavMeshAgent> ();
		seen = false;
		dest = Vector3.positiveInfinity;
		signalDest = Vector3.positiveInfinity;
		searchTimer = 10;
        current = State.Sleep;
        players = getPlayers ();
		print ("Num players: " + players.Length);
		anim = gameObject.GetComponentInChildren<Animator> ();
	}


    //Do damage to payers
	private void LateUpdate(){
		if (Time.timeScale != 0) {
			if (current == State.Attack && target.tag=="Player" && target.GetComponent<PlayerHP> ().current - damage >= 0) {
				if (target.GetComponent<PlayerHP> ().current - damage <= 0) {
					current = State.Search;
				}
				doDamage (target);
			}
		}
	}

	// Update is called once per frame
	private void Update () {
		if (players.Length < 1) {
			players = getPlayers ();
			return;
		}
		//Debug.Log (current+" "+Vector3.Magnitude (getClosestPlayer () - transform.position));
		if (current == State.Chase) {
			target = checkPlayer ();
			dest = target.transform.position;
			seen = target!=gameObject;

			if (Vector3.Magnitude (getClosestPlayer () - transform.position) < 5) {
				anim.SetBool ("run 0", false);
				anim.SetBool ("isAtk", true);
				current = State.Attack;
			} else if (seen) {
				agent.destination = dest;
				//Checks that signal from sentry is valid and accurate.
			} else if (!float.IsPositiveInfinity (signalDest [0]) && Vector3.Magnitude (getClosestPlayer () - signalDest) < 10) {
				//Follow dest given by sentry
				agent.destination = signalDest;
			} else {

				if (Vector3.Magnitude (getClosestPlayer () - transform.position) < 30) {
					//Go towards players approxomate position
					agent.destination = getPlayerPos ();
				} else {
					//transform.Rotate (Vector3.up);
					agent.velocity=Vector3.zero;
					anim.SetBool ("search", true);
					current = State.Search;
				}
			}
		} else if (current == State.Attack) {
			float dist = Vector3.Magnitude (getClosestPlayer () - transform.position);
			agent.velocity = Vector3.zero;
			if (dist > 1 && dist < 5){
				agent.destination = getClosestPlayer ();
			} else if(dist>=5){
				current = State.Search;
				anim.SetBool ("isAtk", false);
				anim.SetBool ("run 0", true);
				agent.destination = getClosestPlayer ();
			}
		}else if (current == State.Sleep) {
			agent.velocity = Vector3.zero;
            if (intial == 1) {
                anim.SetFloat("Blend", 1);
            }
            else {
                anim.SetFloat("Blend", -1);
            }
			
			if (Vector3.Magnitude (getClosestPlayer () - transform.position) < 20) {
				current = State.Awake;
			}
		} else if (current == State.Awake) {
			//spotlight.intensity = 20;
			anim.SetFloat("Blend",1);
			dest = getClosestPlayer ();
			current = State.Chase;
			anim.SetBool ("run 0", true);
		} else if (current == State.Search) {
			if (searchTimer <= 0) {
				//agent.destination = getPlayerPos ();
				searchTimer = 10;
                anim.SetFloat("Blend", 1);
                //anim.SetBool("search",false);
                current = State.Sleep;
                anim.SetBool ("run 0", false);
			} else {
				searchTimer -= 0.01f;
				target = checkPlayer ();
				if (target != gameObject) {
					searchTimer = 0;
					dest = target.transform.position;
					anim.SetBool("search",false);
					current = State.Chase;
					anim.SetBool ("run 0", true);
				}
			}
		}
	}
}