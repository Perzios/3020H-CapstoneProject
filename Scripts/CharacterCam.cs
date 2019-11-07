using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCam : MonoBehaviour
{

    public Camera cam ,cam4;

    //Rotates player in direction of camera
    void Update()
    {
        if (cam.isActiveAndEnabled)
        {
            var CharacterRot = cam.transform.rotation;
            CharacterRot.x = 0;
            CharacterRot.z = 0;
            transform.rotation = CharacterRot;
        }
        else if (cam4.isActiveAndEnabled)
        {
            var CharacterRot = cam4.transform.rotation;
            CharacterRot.x = 0;
            CharacterRot.z = 0;
            transform.rotation = CharacterRot;
        }
    }
}
