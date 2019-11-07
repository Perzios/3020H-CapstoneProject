using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Spawn a random number of prefabs on NavMesh
public class SpawnRandom : MonoBehaviour {
	public int range, number;
	private Vector3 center;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		float counter = 0;
		while (counter < number) {
			Vector2 rndPnt = Random.insideUnitCircle * range;
			Vector3 pnt = transform.position+ new Vector3(rndPnt.x,0,rndPnt.y);
			NavMeshHit hit;
			if (NavMesh.SamplePosition (pnt, out hit, 5.0f, NavMesh.AllAreas)) {
				Instantiate (prefab, pnt, Quaternion.identity);
			} 
			counter += 1;
		}
	}
}