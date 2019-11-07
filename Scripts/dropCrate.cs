using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drops a crate when crate is hit by magic arrow

public class dropCrate : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.transform.tag == ("magicArrow"))
        {

            Destroy(other.gameObject);
            gameObject.transform.GetChild(0).parent = null;

        }
    }


    //Debug used to drop all crates 
    /*private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            gameObject.transform.GetChild(0).parent = null;

        }
    }*/
}
