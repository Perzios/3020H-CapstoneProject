using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Switch player camera to aim camera and back

public class SwitchCam : MonoBehaviour
{

    public GameObject ThirdCam, aimCam, target;
    public int camMode;

    private void Awake()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.InputController.isAim)
        {
            target.SetActive(true);
            StartCoroutine(aimChange());
        }
        else if (GameManager.Instance.InputController.isAim == false)
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
