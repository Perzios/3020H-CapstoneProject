using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//AI searches for the player using a lantern. Will persue the player if they are caught in the light.

public class LightGuard : Enemy {
	private NavMeshAgent agent;
	private bool seen, checkedCrate;
	private Vector3 dest, origin, crateDest;
	private Random rand;
	private float searchTimer;
	private GameObject[] enemies;
	private GameObject target;
	private Animator anim;
	public int intial;
	private RaycastHit hit;


	public void Awaken(Vector3 playerPos, GameObject col){
		if (current == State.Search) {
			current = State.Chase;
		}
		dest = playerPos;
		agent.destination = playerPos;
		target = col;
	}

	// Use this for initialization
	private void Start () {
		agent = GetComponent<NavMeshAgent> ();
		seen = false;
		dest = transform.position;
		origin = gameObject.transform.position;
		searchTimer = 10;
		current = State.Search;
		players = getPlayers ();
		print ("Num players: " + players.Length);
		anim = gameObject.GetComponentInChildren<Animator> ();
		checkedCrate = false;
	}

	private void LateUpdate(){
		if (Time.timeScale != 0) {
			if (current == State.Attack && target.tag=="Player") {
				//doDamage (target);
				target.GetComponentInParent<PlayerHP>().incHealth(damage);
				Debug.Log ("Attacking "+target.name);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.tag);
		if (col.tag == "Player") {
			dest = col.transform.position;
			current = State.Chase;
			target = col.gameObject;
		}
	}

	// Update is called once per frame
	private void Update () {
		Debug.Log (current);
		if (players.Length < 1) {
			players = getPlayers ();
			return;
		}

		if (current == State.Chase) {
			agent.speed = 10;
			float dist = Vector3.Magnitude (getClosestPlayer () - transform.position);
			if (dist < 5) {
				anim.SetBool ("isAtk", true);
				current = State.Attack;
			} else if (dist < 10) {
				agent.destination = getClosestPlayer ();
			}else{
				current = State.Search;
			}
		} else if (current == State.Attack) {
			float dist = Vector3.Magnitude (getClosestPlayer () - transform.position);
			agent.velocity = Vector3.zero;
			if (dist < 5) {
				agent.destination = getClosestPlayer ();
			} else {
				anim.SetBool ("isAtk", false);
				anim.SetBool ("isMove", true);
				current = State.Search;

				agent.destination = getPlayerPos ();
			}
		} else if (current == State.Search) {
			agent.speed = 5;
			if (Vector3.Magnitude(transform.position-getClosestPlayer())<3){
				current= State.Chase;
			}
			if (Vector3.Magnitude (transform.position - dest) < 1.1 || Vector3.Magnitude(agent.velocity)<1) {
				NavMeshHit hit;
				bool found = false;
				while (!found) {
					Vector2 rndPos = 20 * Random.insideUnitCircle;
					Vector3 testDest = new Vector3 (rndPos.x, 0, rndPos.y);
					testDest += transform.position;
					if (NavMesh.SamplePosition (testDest, out hit, 20, NavMesh.AllAreas)) {
						agent.destination = testDest;
						dest = hit.position;
						found = true;
					}
				}
			} else {
				agent.destination = dest;
			}
		}
	}
}
