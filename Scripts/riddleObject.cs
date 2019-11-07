using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys riddle item when hit

public class riddleObject : MonoBehaviour {

    private ParticleSystem ps;
    public int count = 0;
    public static bool destroyRiddleObject;

    // Use this for initialization
    void Start() {
        ps = GetComponentInChildren<ParticleSystem>();
        destroyRiddleObject = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magicArrow"))
        {
            if (changeRiddle.c == count)
            {
                StartCoroutine("destroy");
                destroyRiddleObject = false;
            }
            else
            {
                other.transform.GetComponentInParent<PlayerHP>().incHealth(-8); //see if works
                destroyRiddleObject = false;
            }

        }
    }

    public void demeterDestroy(){
        if (changeRiddle.c == count)
        {
            StartCoroutine("destroy");
            destroyRiddleObject = false;
        }
    }

    IEnumerator destroy()
    {
        ps.Play();
        changeRiddle.c++;
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}
