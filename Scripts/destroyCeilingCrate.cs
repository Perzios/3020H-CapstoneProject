using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy crate

public class destroyCeilingCrate : MonoBehaviour {

    private ParticleSystem disappear;

	// Use this for initialization
	void Start () {
        disappear = gameObject.GetComponentInChildren<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        if(assembleBoxes.count == 7)
        {

            StartCoroutine("destroy");
            //Destroy(gameObject);

        }
    }

    IEnumerator destroy()
    {
        disappear.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}


