using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys crate after being hit by magic arrow

public class breakWallCrate : MonoBehaviour {
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magicArrow"))
        {

            Destroy(other.gameObject);
            Destroy(gameObject);
            
            
        }
    }
}
