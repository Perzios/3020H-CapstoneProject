using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorGate : MonoBehaviour {

    public GameObject gate;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = gate.GetComponent<Animator>();
	}

    //kill if player falls in floor dungeon

    public void openThegate()
    {
            animator.SetTrigger("floor");
            Destroy(gameObject);
    }
}
