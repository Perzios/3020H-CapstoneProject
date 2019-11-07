using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playes animations on wall

public class wallFire : MonoBehaviour {

    private Animator anim;
    public ParticleSystem ps1, ps2;
    public GameObject bottle , wall;

    public void doTheThing(){
        StartCoroutine(fire());
    }

    IEnumerator fire()
    {
        ps1.Play();
        yield return new WaitForSeconds(5f);
        ps1.Stop();
        //Destroy(ps1);
        ps2.Play();
        yield return new WaitForSeconds(5.5f);
        ps2.Stop();
        //Destroy(ps2);
        bottle.SetActive(true);
        Destroy(wall);
    }
}
