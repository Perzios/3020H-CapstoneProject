using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates crate count if crate collides with a bixCheck Object

public class moveCrate : MonoBehaviour {

    public int x;
    public int y;
    private Rigidbody rb;
    private ParticleSystem ps;
    bool check = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cratevsZombie.count == x)
        {
            ps.Play();
            rb.mass = 35;
        }
        if (cratevsZombie.count == y)
        {
            ps.Play();
            rb.mass = 12;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (check == false && other.transform.tag == "boxCheck")
        {
            check = true;
            cratevsZombie.crates++;
            Debug.Log(cratevsZombie.crates);
        }

    }
}
