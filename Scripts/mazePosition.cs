using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set Demeter to maze start posotion

public class mazePosition : MonoBehaviour {

    public GameObject pos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Demeter")
        {
            //other.gameObject.transform.position = pos.transform.position;
            other.gameObject.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z);
            //Destroy(gameObject);
        }
        
    }
}
