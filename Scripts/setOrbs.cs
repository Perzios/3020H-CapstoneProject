using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Activates portal when all artefacts are found

public class setOrbs : MonoBehaviour {


    public RawImage img;
    public GameObject orbs,gate;
    
    private bool orb;
    
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        orb = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && orb == false && artefacts.count == 8)

        {
            ps.Play();
            gate.SetActive(true);
            orb = true;
        }
    }


    IEnumerator findOrb()
    {
        img.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        img.gameObject.SetActive(false);
        
    }
}
