using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggers levers event when hit by dagger

public class handleDown : MonoBehaviour {

    private Animator animator;
    [SerializeField]
    public GameObject gate;
    public GameObject floor;
    private ParticleSystem ps;
    public GameObject blueOrb;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        ps = gate.GetComponentInChildren<ParticleSystem>();
    }
	
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("dagger"))
        {
            animator.SetTrigger("handle");
            ps.Play();
            Destroy(floor);
            blueOrb.SetActive(true);
        }
    }
}
