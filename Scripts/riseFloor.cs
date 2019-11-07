using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lifts the platform to top when all crates has been pushed into their slots

public class riseFloor : MonoBehaviour
{

    private Vector3 endPos;
    private Vector3 endPos2;
    private Vector3 currentPos , low;
    public float movementSpeed = 5f;
    bool done;
    bool demOn , rise , up , changed;
    public float nextRise;
    int cnt = 0;

    // Use this for initialization
    void Start()
    {
        currentPos = transform.position;
        low = currentPos;
        endPos = new Vector3(transform.position.x, 22.35f, transform.position.z);
        endPos2 = new Vector3(transform.position.x, 89.41756f, transform.position.z);
        done = false;
        demOn = false;
        rise = false;
        up = true;
        nextRise = 5.0f;
        changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if all boxes in holes
        if (cratevsZombie.count == 12 && cnt == 0)
        {
            rise = true;
            cnt++;
        }
       
        if (rise) {
            if (transform.position == endPos2) {
                up = false;
                if (!changed) {
                    nextRise = Time.time + 5;
                    changed = true;
                }
                
            }
            if (!up && Time.time >= nextRise)
            {
                transform.position = Vector3.MoveTowards(transform.position, low, movementSpeed * Time.deltaTime);
                changed = false;
            }

            if (transform.position == low)
            {
                up = true;
                if (!changed)
                {
                    nextRise = Time.time + 5;
                    changed = true;
                }
            }
            if (up && Time.time >= nextRise)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos2, movementSpeed * Time.deltaTime);
                changed = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Demeter" && cratevsZombie.crates == 12)
        {
            demOn = true;
        }        
    }
    

}
