using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Breaks crate when hit by arrow and adds a key to the players inventory

public class BreakCrate : MonoBehaviour {

    
    public GameObject obj;
    //public GameObject key;
    public ParticleSystem particle;
    public GameObject player;
    public GameObject lantern;
   

    private void Start()
    {
        particle.Play();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {

            Destroy(other.gameObject);
            Instantiate(obj, transform.position, transform.rotation);
            Destroy(gameObject);

            obj.SetActive(true);
            player.GetComponent<Inventory>().addSlot("key");
            //key.SetActive(true);
        }
    }
}
