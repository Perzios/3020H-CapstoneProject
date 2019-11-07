using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawnn zombies in room 10

public class zombieSpawn : MonoBehaviour {
	public GameObject zombiePrefab;
    int cnt = 0;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		coroutine = spawnZombie(5.0f, 1, 3);
		StartCoroutine(coroutine);
	}

	private IEnumerator spawnZombie(float health, float minWait, float MaxWait){
		while (cnt < 8) {
			yield return new WaitForSeconds(Random.Range(minWait,MaxWait));
			GameObject zombie = Instantiate (zombiePrefab, transform.position, Quaternion.identity);
            cnt++;
			zombie.GetComponent<Health> ().maxHealth = health;
			zombie.GetComponent<Sentry> ().current = Enemy.State.Search;
			print ("Brute spawned");
		}
	}

  
}
