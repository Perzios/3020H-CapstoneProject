using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls camera switching for Demeter

public class DemeterSwitchCam : MonoBehaviour {

    public GameObject  ThirdCam, aimCam, target;

    private void Awake()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.InputController2.isAim)
        {
            target.SetActive(true);
            StartCoroutine(aimChange());
        }
        else if (GameManager.Instance.InputController2.isAim == false)
        {
            target.SetActive(false);
            StartCoroutine(camChange());
        }
    }

    IEnumerator camChange()
    {
        yield return new WaitForSeconds(0.3f);
            ThirdCam.SetActive(true);
            aimCam.SetActive(false);
    }


    IEnumerator aimChange()
    {
        yield return new WaitForSeconds(0.3f);
        ThirdCam.SetActive(false);
        aimCam.SetActive(true);
    }
}
