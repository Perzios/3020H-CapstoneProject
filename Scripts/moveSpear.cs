using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves spear towards hammer to start hammer event

public class moveSpear : MonoBehaviour {

    
    public GameObject endPos;
    public float movementSpeed = 5f;
    public bool hit = false;
    bool ran = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            hit = true;
            
        }

    }

    private void Update()
    {
        if (hit) {
            if (transform.position != endPos.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, movementSpeed * Time.deltaTime);
            }
        }
        if (transform.position == endPos.transform.position && ran == false) {
            ran = true;
            endPos.GetComponent<Animator>().SetTrigger("hammer");
            endPos.GetComponent<wallFire>().doTheThing();
        }
    }





}
