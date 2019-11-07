using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Removes the water from the floor and lift a platform for persephone to stand on

public class stopWater : MonoBehaviour {

    private Animator anim;
    public GameObject water1, water2, water3, water4, floor;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        floor.GetComponent<MeshCollider>().enabled = false;
        gameObject.SetActive(false);        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            anim.SetTrigger("button");
            water3.GetComponent<Animator>().SetTrigger("water");
            StartCoroutine("water");
        }
    }

    IEnumerator water()
    {
        yield return new WaitForSeconds(5f);
        Destroy(water3);
        floor.GetComponent<Animator>().SetTrigger("floor");
        yield return new WaitForSeconds(1.6f);
        floor.GetComponent<MeshCollider>().enabled = true;
        floor.GetComponent<Rigidbody>().useGravity = true;
        floor.GetComponent<Animator>().applyRootMotion = true;
    }

}
