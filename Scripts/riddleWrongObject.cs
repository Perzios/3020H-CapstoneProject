using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lose HP when player selected wrong item

public class riddleWrongObject : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("magicArrow") /*or magic*/)
        {
            other.transform.GetComponentInParent<PlayerHP>().incHealth(-8);
        }
    }
}
