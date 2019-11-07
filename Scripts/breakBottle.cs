using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destoys bottle when hit by dagger

public class breakBottle : MonoBehaviour {

    public GameObject obj;
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("dagger"))
        {
            Instantiate(obj, transform.position, transform.rotation);
            Destroy(gameObject);
            player.GetComponentInChildren<Inventory>().addSlot("doorHandle");
            //open inventory box
        }
    }
}
