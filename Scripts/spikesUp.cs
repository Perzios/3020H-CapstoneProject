using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//playes spike animation

public class spikesUp : MonoBehaviour {

    private Animator animator;
    public int target;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(riddleStart.riddleRoom == true)
        {
            timer += Time.deltaTime;
        }

        if(target < timer)
        {
            animator.SetTrigger("spikesUp");
        }

        
	}
}
