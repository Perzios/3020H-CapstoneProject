using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

/**
 * The sentry is a NPC that looks out for the players. Once a player is spotted the sentry sends
 * out a signal to other enemies alerting them to the players position.
 */
public class Sentry : Enemy {
	private NavMeshAgent agent;
	private bool seen;
	private Vector3 dest;
	private Random rand;
	private float searchTimer;
	private GameObject[] enemies;
	private GameObject target;
	private Animator anim;
	private bool firstSeen;
	private AudioSource scream;
    //private Light spotlight;


    // Use this for initialization
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        seen = false;
        dest = Vector3.positiveInfinity;
        current = State.Sleep;
        searchTimer = 0;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        players = getPlayers();
        anim = gameObject.GetComponentInChildren<Animator>();
        firstSeen = true;
		scream = gameObject.GetComponent<AudioSource> ();
        //spotlight = GetComponentInChildren<Light> ();
        //spotlight.intensity = 0;
    }

	//Called by broadcast/external script to wake up npc
    public void Awaken(Vector3 playerPos)
    {
        if (current == State.Sleep)
        {
            current = State.Awake;
        }
        dest = playerPos;
    }

	//Do damage to player
    private void LateUpdate(){
		if (Time.timeScale != 0) {
			if (current == State.Attack) {
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
		//Search state looks for player
		if (current == State.Search) {
			target = checkPlayer();//Find player dest
			dest = target.transform.position;
			seen = !(dest == transform.position);

			if (seen) {
				searchTimer = 0;
				//Notify
				if (Vector3.Magnitude (getClosestPlayer () - transform.position) < 5) {
					anim.SetBool ("run 0", false);
					anim.SetBool ("isAtk", true);
					current = State.Attack;
				}
				for (int i = 0; i < enemies.Length; ++i) {
					if (Vector3.Magnitude(enemies[i].transform.position-transform.position) < 100){
						if (enemies [i] != gameObject) {
                            enemies [i].SendMessage("Awaken", dest);
							print ("Wake up");
						}
					}
				}
				agent.destination = dest;
			} else {
				firstSeen = true;
				print ("Not seen");
				if (Vector3.Magnitude (getClosestPlayer() - transform.position) < 30) {
					agent.destination = getPlayerPos();
				} else {
					transform.Rotate (Vector3.up);
					if (searchTimer == 0) {
						agent.destination = getPlayerPos ();
						searchTimer = 50;
					} else {
						searchTimer -= 0.01f;
					}
				}
			}
			if (Vector3.Magnitude(agent.velocity) > 0) {
				anim.SetBool ("walk/run", true);
			} else {
				anim.SetBool ("walk/run", false);
			}
		//Tries to do damage to player
		} else if (current == State.Attack) {
			Debug.Log ("attack");
			float dist = Vector3.Magnitude (getClosestPlayer () - transform.position);
			agent.velocity = Vector3.zero;
			if (dist > 5 && dist < 10){
				agent.destination = getClosestPlayer ();
			} else {
				current = State.Search;
				anim.SetBool ("isAtk", false);
				anim.SetBool ("run 0", true);
				agent.destination = getClosestPlayer ();
			}
		}else if (current == State.Sleep) {
			if (Vector3.Magnitude (getClosestPlayer() - transform.position) < 20) {
				anim.SetBool ("Spotted", firstSeen);
				current = State.Awake;
			}
		//move from sleep to search state
		} else if (current == State.Awake) {
			if (PlayerPrefs.GetInt ("sound", 1) == 1) {
				scream.Play ();
			}
			dest = getClosestPlayer ();
			current = State.Search;
			anim.SetBool ("Spotted", false);
		}



	}

}