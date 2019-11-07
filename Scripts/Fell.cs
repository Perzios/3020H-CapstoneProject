using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Checks if players found correct boxes, if they did they trigger the event that allows them to open the door

public class Fell : MonoBehaviour {

    public float z;
    private MeshRenderer mr;
    
    private Vector3 currentPos;
    private Vector3 endPos;
    public float movementSpeed;
    public bool moveO = false;
    public ParticleSystem[] particles;
    public bool green ,updated ,played;
    public GameObject door;
    private Animator animator;
    public RawImage img;

    private void Start()
    {
        //mr = GetComponent<MeshRenderer>();
        particles = GetComponentsInChildren<ParticleSystem>();
       
        currentPos = new Vector3(transform.position.x, 38.59963f, transform.position.z);
        endPos = new Vector3(-431, 38.59963f, z);
        movementSpeed = 5f;
        updated = false;
        played = false;
        animator = door.GetComponent<Animator>();
    }


    private void Update()
    {
        if (assembleBoxes.count == 7)

        {
            moveO = true;
            particles[0].Play();
            //StartCoroutine("move");
        }

        if (moveO)
        {
            if (transform.position != endPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, movementSpeed * Time.deltaTime);

            }
        }

        if(transform.position == endPos && updated == false)
        {
            updated = true;
            assembleBoxes.count2++;
        }

        if(assembleBoxes.start == true && played == false)
        {
            played = true;
            StartCoroutine(lights());
        }
    }

    //oncol

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("room5Floor"))
        {
            //assembleBoxes.fell = true;
            assembleBoxes.count++;
        }
        
    }


    IEnumerator lights()
    {
        particles[1].Play();
        yield return new WaitForSeconds(5.5f);
        particles[2].Play();
        yield return new WaitForSeconds(5.5f);
        particles[3].Play();
        yield return new WaitForSeconds(2f);
        img.gameObject.SetActive(true);
       //display thing;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow") && green==true)
        {
            animator.SetTrigger("woodDoor");
            img.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
