using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves Persephone to given coordinates

public class movePers : MonoBehaviour {

    public GameObject pers;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pers.transform.position = new Vector3(-552.83f, 45.284f, -91.89f);
            Destroy(gameObject);
        }
    }
}
