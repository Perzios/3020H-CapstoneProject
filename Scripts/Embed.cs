using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Embed arrow into colliding object

public class Embed : MonoBehaviour
{

    Rigidbody rb;

    public AudioClip Impact;
    public AudioSource source;
    public GameObject explode , contact;
    public bool magicArrow;

    bool embeded = false;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        embeded = true;
        //rb.velocity = Vector3.zero;
        EmbedArrow();
        transform.SetParent(col.transform);

        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Health>().incHealth(-2);
            if (magicArrow)
            {
                if (startZombies.start)
                {
                    cratevsZombie.count++;
                }
            }
            
        }
            
        
    }

    void EmbedArrow()
    {
        source.PlayOneShot(Impact);
        transform.GetComponent<ArrowSpawn>().enabled = false;
        //transform.GetComponentInChildren<ParticleSystem>().Stop();
        //transform.GetComponentInChildren<FlameAudio>().StopPlay();
        
        rb.isKinematic = true;
        rb.useGravity = false;
        Destroy(gameObject, 7f);
        //rb.isKinematic = false;
        //Instantiate(explode, contact.transform.position, contact.transform.rotation);
    }
}
